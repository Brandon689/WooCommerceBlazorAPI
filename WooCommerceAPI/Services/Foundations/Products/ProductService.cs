using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal partial class ProductService : IProductService
    {
        private readonly IWooCommerceBroker wooCommerceBroker;

        public ProductService(IWooCommerceBroker wooCommerceBroker)
        {
            this.wooCommerceBroker = wooCommerceBroker;
        }

        public ValueTask<Product> SendProductAsync(Product product) =>
        TryCatch(async () =>
        {
            //ValidateProductOnSend(product);
            ExternalProduct externalProductRequest = ConvertToProductRequest(product);
            ExternalProduct externalProductResponse =
                await this.wooCommerceBroker.PostProductRequestAsync(externalProductRequest);

            return ConvertToProduct(product, externalProductResponse);
        });

        public ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations productVariations) =>
        TryCatch(async () =>
        {
            //ValidateProductOnSend(Product);
            ExternalProductVariationsRequest externalProductRequest = ConvertToProductVariationsRequest(productVariations.Request);
            ExternalProduct externalProductResponse =
                await this.wooCommerceBroker.PostProductVariationsRequestAsync(externalProductRequest, productVariations.Request.ProductId);

            Product product = new();
            productVariations.Response = ConvertToProduct(product, externalProductResponse);
            return productVariations;
        });

        public ValueTask<Product> GetProductAsync(int id) =>
        TryCatch(async () =>
        {
            //ValidateGetProductOnSend(getProduct);
            ExternalProduct externalGetProductResponse =
                await this.wooCommerceBroker.GetProductRequestAsync(id);

            return ConvertToProduct(new Product(), externalGetProductResponse);
        });

        public ValueTask<Product[]> GetAllProductsAsync(int page, int perPage) =>
        TryCatchAll(async () =>
        {
            //ValidateGetProductOnSend(getProduct);
            ExternalProduct[] externalGetProductResponse =
                await this.wooCommerceBroker.GetAllProductsRequestAsync(page, perPage);

            Product[] products = new Product[externalGetProductResponse.Length];
            for (int i = 0; i < externalGetProductResponse.Length; i++)
            {
                products[i] = ConvertToProduct(new Product(), externalGetProductResponse[i]);
            }
            return products;
        });

        //public ValueTask<Product> UpdateProductAsync(Product product, int id) =>
        //TryCatch(async () =>
        //{
        //    if (product.Request == null && product.Response != null)
        //    {
        //        ConvertResponseToProductRequest(product);
        //    }
        //    //ValidateGetProductOnSend(getProduct);
        //    var externalProductRequest = new ExternalProductRequest()
        //    {
        //        Name = product.Request.Name,
        //        RegularPrice = product.Request.RegularPrice,
        //        Description = product.Request.Description,
        //        Type = product.Request.Type
        //    };
        //    var externalGetProductResponse =
        //        await this.wooCommerceBroker.UpdateProductRequestAsync(externalProductRequest, id);

        //    return new Product();
        //    //return ConvertToProduct(new Product(), externalGetProductResponse);
        //});


        public async ValueTask<Product> UpdateProductAsync(Product product, int id)
        {
            //ValidateGetProductOnSend(getProduct);
            //var externalProductRequest = new ExternalProductRequest()
            //{
            //    Name = product.Request.Name,
            //    RegularPrice = product.Request.RegularPrice,
            //    Description = product.Request.Description,
            //    Type = product.Request.Type,
            //    StockQuantity = product.Request.StockQuantity,
            //    StockStatus = product.Request.StockStatus,
            //    ManageStock = product.Request.ManageStock,
            //    Sku = product.Request.Sku,
            //};
            var externalProductRequest = ConvertToProductRequest(product);
            var externalGetProductResponse =
                await this.wooCommerceBroker.UpdateProductRequestAsync(externalProductRequest, id);
            return ConvertToProduct(new Product(), externalGetProductResponse);
        }

        private static ExternalProduct ConvertToProductRequest(Product product)
        {
            var externalProductRequest = new ExternalProduct()
            {
                Name = product.Name,
                RegularPrice = product.RegularPrice,
                Description = product.Description,
                Type = product.Type,
                StockQuantity = product.StockQuantity,
                CatalogVisibility = product.CatalogVisibility,
                ShortDescription = product.ShortDescription,
                Featured = product.Featured,
                StockStatus = product.StockStatus,
                Slug = product.Slug,
                Sku = product.Sku,
                ManageStock = product.ManageStock,
                Status = product.Status,
                Permalink = product.Permalink,
                SalePrice = product.SalePrice,
                Weight = product.Weight,
                Dimensions = product.Dimensions,
            };
            if (product.Images != null)
            {
                externalProductRequest.Images = product.Images.Select(message =>
                {
                    return new ExternalImage()
                    {
                        Id = message.Id,
                        Name = message.Name,
                        Src = message.Src,
                        Alt = message.Alt,
                        DateModified = message.DateModified,
                        DateCreated = message.DateCreated,
                        DateCreatedGmt = message.DateCreatedGmt,
                        DateModifiedGmt = message.DateModifiedGmt
                    };
                }).ToArray();
            }
            if (product.Attributes != null)
            {
                externalProductRequest.Attributes = product.Attributes.Select(attribute =>
                {
                    return new ExternalProductAttribute
                    {
                        Id = attribute.Id,
                        Position = attribute.Position,
                        Visible = attribute.Visible,
                        Name = attribute.Name,
                        Variation = attribute.Variation,
                        Options = attribute.Options
                    };
                }).ToArray();
            }
            if (product.MetaData != null)
            {

                externalProductRequest.MetaData = product.MetaData.Select(x =>
                {
                    return new ExternalProductMetadata
                    {

                    };
                }).ToArray();
                //externalProductRequest.MetaData = product.MetaData.Select(x =>
                //{
                //    return new ExternalProductMetadata
                //    {
                //        //Key = x.Key,
                //        //Value = x.Value
                //    };
                //}).ToArray();
            }
            return externalProductRequest;
        }

        private Product ConvertToProduct(
            Product Product,
            ExternalProduct externalProductResponse)
        {
            return new Product
            {
                Backorders = externalProductResponse.Backorders,
                BackordersAllowed = externalProductResponse.BackordersAllowed,
                Backordered = externalProductResponse.Backordered,
                ButtonText = externalProductResponse.ButtonText,
                CatalogVisibility = externalProductResponse.CatalogVisibility,
                Categories = externalProductResponse.Categories.Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug
                }).ToArray(),
                DateCreated = externalProductResponse.DateCreated,
                DateCreatedGmt = externalProductResponse.DateCreatedGmt,
                DateModified = externalProductResponse.DateModified,
                DateModifiedGmt = externalProductResponse.DateModifiedGmt,
                DateOnSaleFrom = externalProductResponse.DateOnSaleFrom,
                DateOnSaleFromGmt = externalProductResponse.DateOnSaleFromGmt,
                DateOnSaleTo = externalProductResponse.DateOnSaleTo,
                DateOnSaleToGmt = externalProductResponse.DateOnSaleToGmt,
                //DefaultAttributes = externalProductResponse.DefaultAttributes.Select(da => new DefaultAttribute
                //{
                //    Id = da.Id,
                //    Name = da.Name,
                //    Option = da.Option
                //}).ToArray(),
                Description = externalProductResponse.Description,
                //Dimensions = new Dimensions
                //{
                //    Length = externalProductResponse.Dimensions.Length,
                //    Width = externalProductResponse.Dimensions.Width,
                //    Height = externalProductResponse.Dimensions.Height
                //},


                Id = externalProductResponse.Id,
                Name = externalProductResponse.Name,
                RegularPrice = externalProductResponse.RegularPrice,
                Type = externalProductResponse.Type,
                Status = externalProductResponse.Status,
                Price = externalProductResponse.Price,
                Featured = externalProductResponse.Featured,
                Slug = externalProductResponse.Slug,
                StockQuantity = externalProductResponse.StockQuantity,
                SoldIndividually = externalProductResponse.SoldIndividually,
                Weight = externalProductResponse.Weight,
                StockStatus = externalProductResponse.StockStatus,
                ManageStock = externalProductResponse.ManageStock,
                Attributes = externalProductResponse.Attributes.Select(x =>
                {
                    return new ProductAttribute
                    {
                        Id = x.Id,
                        Position = x.Position,
                        Name = x.Name,
                        Visible = x.Visible,
                        Variation = x.Variation,
                        Options = x.Options
                    };
                }).ToArray(),
                //CreatedDate = this.dateTimeBroker.ConvertToDateTimeOffSet(externalProductResponse.Created),
                MetaData = externalProductResponse.MetaData.Select(x =>
                {
                    return new ProductMetadata
                    {
                        Id = x.Id,
                        Key = x.Key,
                        Value = x.Value
                    };
                }).ToArray(),
                Images = externalProductResponse.Images.Select(x =>
                {
                    return new Image
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Src = x.Src,
                        Alt = x.Alt,
                        DateCreated = x.DateCreated,
                        DateCreatedGmt = x.DateCreatedGmt,
                        DateModified = x.DateModified,
                        DateModifiedGmt = x.DateModifiedGmt
                    };
                }).ToArray()
            };

            return Product;
        }

        private static ExternalProductVariationsRequest ConvertToProductVariationsRequest(ProductVariationsRequest product)
        {
            return new ExternalProductVariationsRequest
            {
                Create = product.Create.Select(create =>
                    new ExternalProductVariation
                    {
                        RegularPrice = create.RegularPrice,
                        Attributes = create.Attributes.Select(attr =>
                            new ExternalProductVariationAttribute
                            {
                                //Id = attr.Id,
                                Option = attr.Option,
                                Name = attr.Name
                            }).ToArray(),
                        Image = create.Image == null ? null : new ExternalID(id: create.Image.Id)
                    }).ToArray()
            };
        }
    }
}
