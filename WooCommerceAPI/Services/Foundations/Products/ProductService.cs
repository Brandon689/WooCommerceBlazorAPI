using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductTags;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal partial class ProductService(IWooCommerceBroker wooCommerceBroker) : IProductService
    {
        private readonly IWooCommerceBroker wooCommerceBroker = wooCommerceBroker;

        public async ValueTask<ProductVariation[]> GetProductVariations(int id)
        {
            var c = await this.wooCommerceBroker.GetProductVariations(id);
            return c;
        }

        public ValueTask<Product> SendProductAsync(Product product) =>
        TryCatch(async () =>
        {
            //ValidateProductOnSend(product);
            ExternalProduct externalProductRequest = ConvertToProductRequest(product);
            ExternalProduct externalProductResponse =
                await this.wooCommerceBroker.PostProductRequestAsync(externalProductRequest);

            return ConvertToProduct(externalProductResponse);
        });

        public ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations productVariations) =>
        TryCatch(async () =>
        {
            //ValidateProductOnSend(Product);
            ExternalProductVariationsRequest externalProductRequest = ConvertToProductVariationsRequest(productVariations.Request);
            ExternalProduct externalProductResponse =
                await this.wooCommerceBroker.PostProductVariationsRequestAsync(externalProductRequest, productVariations.Request.ProductId);

            productVariations.Response = ConvertToProduct(externalProductResponse);
            return productVariations;
        });

        public ValueTask<Product> GetProductAsync(int id) =>
        TryCatch(async () =>
        {
            //ValidateGetProductOnSend(getProduct);
            ExternalProduct externalGetProductResponse =
                await this.wooCommerceBroker.GetProductRequestAsync(id);

            return ConvertToProduct(externalGetProductResponse);
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
                products[i] = ConvertToProduct(externalGetProductResponse[i]);
            }
            return products;
        });

        public async ValueTask<Product> UpdateProductAsync(Product product, int id)
        {
            //ValidateGetProductOnSend(getProduct);
            var externalProductRequest = ConvertToProductRequest(product);
            var externalGetProductResponse =
                await this.wooCommerceBroker.UpdateProductRequestAsync(externalProductRequest, id);
            return ConvertToProduct(externalGetProductResponse);
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
                Dimensions = new ExternalDimensions()
                {
                    Height = product.Dimensions?.Height,
                    Width = product.Dimensions?.Width,
                    Length = product.Dimensions?.Length,
                },
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

        private Product ConvertToProduct(ExternalProduct externalProductResponse)
        {
            return new Product
            {
                Backorders = externalProductResponse.Backorders,
                BackordersAllowed = externalProductResponse.BackordersAllowed,
                Backordered = externalProductResponse.Backordered,
                ButtonText = externalProductResponse.ButtonText,
                CatalogVisibility = externalProductResponse.CatalogVisibility,
                Categories = externalProductResponse.Categories?.Select(c => new Category
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
                DefaultAttributes = externalProductResponse.DefaultAttributes?.Select(da => new DefaultAttribute
                {
                    Id = da.Id,
                    Name = da.Name,
                    Option = da.Option
                }).ToArray(),
                Description = externalProductResponse.Description,
                Dimensions = new Dimensions
                {
                    Length = externalProductResponse.Dimensions?.Length,
                    Width = externalProductResponse.Dimensions?.Width,
                    Height = externalProductResponse.Dimensions?.Height
                },
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
                Links = new Links()
                {
                    Self = externalProductResponse.Links.Self.Select(x =>
                    {
                        return new Self
                        {
                            Href = x.Href,
                        };
                    }).ToArray(),
                    Collection = externalProductResponse.Links.Collection.Select(x =>
                    {
                        return new Collection
                        {
                            Href = x.Href
                        };
                    }).ToArray()
                },
                Tags = externalProductResponse.Tags?.Select(x =>
                {
                    return new Tag
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Slug = x.Slug,
                    };
                }).ToArray(),
                Attributes = externalProductResponse.Attributes?.Select(x =>
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
                MetaData = externalProductResponse.MetaData?.Select(x =>
                {
                    return new ProductMetadata
                    {
                        Id = x.Id,
                        Key = x.Key,
                        Value = x.Value
                    };
                }).ToArray(),
                Images = externalProductResponse.Images?.Select(x =>
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
                }).ToArray(),
                Variations = externalProductResponse.Variations
            };
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
                            new ExternalVariationAttribute
                            {
                                //Id = attr.Id,
                                Option = attr.Option,
                                Name = attr.Name
                            }).ToArray(),
                        Image = create.Image == null ? null : new ExternalImage(id: create.Image.Id)
                    }).ToArray()
            };
        }
    }
}
