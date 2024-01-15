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

            ExternalProductRequest externalProductRequest = ConvertToProductRequest(product);
            ExternalProductResponse externalProductResponse =
                await this.wooCommerceBroker.PostProductRequestAsync(externalProductRequest);

            return ConvertToProduct(product, externalProductResponse);
        });

        public ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations productVariations) =>
        TryCatch(async () =>
        {
            //ValidateProductOnSend(Product);

            ExternalProductVariationsRequest externalProductRequest = ConvertToProductVariationsRequest(productVariations.Request);
            string f = Newtonsoft.Json.JsonConvert.SerializeObject(externalProductRequest);
            File.WriteAllText("../../../epvr.json", f);
            ExternalProductResponse externalProductResponse =
                await this.wooCommerceBroker.PostProductVariationsRequestAsync(externalProductRequest, productVariations.Request.ProductId);

            Product product = new();
            productVariations.Response = ConvertToProduct(product, externalProductResponse);
            return productVariations;
        });

        public ValueTask<Product> GetProductAsync(int id) =>
        TryCatch(async () =>
        {
            //ValidateGetProductOnSend(getProduct);

            ExternalProductResponse externalGetProductResponse =
                await this.wooCommerceBroker.GetProductRequestAsync(id);

            return ConvertToProduct(new Product(), externalGetProductResponse);
        });

        public ValueTask<Product[]> GetAllProductsAsync(int page, int perPage) =>
        TryCatchAll(async () =>
        {
            //ValidateGetProductOnSend(getProduct);

            ExternalProductResponse[] externalGetProductResponse =
                await this.wooCommerceBroker.GetAllProductsRequestAsync(page, perPage);

            Product[] products = new Product[externalGetProductResponse.Length];
            for (int i = 0; i < externalGetProductResponse.Length; i++)
            {
                products[i] = ConvertToProduct(new Product(), externalGetProductResponse[i]);
            }
            return products;
        });

        public ValueTask<Product> UpdateProductAsync(Product product, int id) =>
        TryCatch(async () =>
        {
            if (product.Request == null && product.Response != null)
            {
                ConvertResponseToProductRequest(product);
            }
            //ValidateGetProductOnSend(getProduct);
            var externalProductRequest = new ExternalProductRequest()
            {
                Name = product.Request.Name,
                RegularPrice = product.Request.RegularPrice,
                Description = product.Request.Description,
                Type = product.Request.Type
            };
            var externalGetProductResponse =
                await this.wooCommerceBroker.UpdateProductRequestAsync(externalProductRequest, id);

            return new Product();
            //return ConvertToProduct(new Product(), externalGetProductResponse);
        });
        //{
        //    var externalProductRequest = new ExternalProductRequest()
        //    {
        //        Name = product.Request.Name,
        //        RegularPrice = product.Request.RegularPrice,
        //        Description = product.Request.Description,
        //        Type = product.Request.Type
        //    };
        //    var externalGetProductResponse =
        //        await this.wooCommerceBroker.UpdateProductRequestAsync(externalProductRequest, id);

        //    return null;
        //    //return ConvertToProduct(new Product(), externalGetProductResponse);
        //}

        private static ExternalProductRequest ConvertToProductRequest(Product product)
        {
            var externalProductRequest = new ExternalProductRequest()
            {
                Name = product.Request.Name,
                RegularPrice = product.Request.RegularPrice,
                Description = product.Request.Description,
                Type = product.Request.Type
            };
            if (product.Request.Images != null)
            {
                externalProductRequest.Images = product.Request.Images.Select(message =>
                {
                    return new ExternalID(id: message.Id);
                }).ToArray();
            }
            if (product.Request.Attributes != null)
            {
                externalProductRequest.Attributes = product.Request.Attributes.Select(attribute =>
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
            if (product.Request.MetaData != null)
            {
                externalProductRequest.Metadata = product.Request.MetaData.Select(x =>
                {
                    return new ExternalProductMetadata
                    {
                        Key = x.Key,
                        Value = x.Value
                    };
                }).ToArray();
            }
            return externalProductRequest;
        }

        private Product ConvertToProduct(
            Product Product,
            ExternalProductResponse externalProductResponse)
        {

            Product.Response = new ProductResponse
            {
                Id = externalProductResponse.Id,
                Name = externalProductResponse.Name,
                RegularPrice = externalProductResponse.RegularPrice,
                Description = externalProductResponse.Description,
                Type = externalProductResponse.Type,
                DateCreated = externalProductResponse.DateCreated,
                DateModified = externalProductResponse.DateModified,
                DateModifiedGmt = externalProductResponse.DateModifiedGmt,
                DateOnSaleFrom = externalProductResponse.DateOnSaleFrom,
                DateOnSaleFromGmt = externalProductResponse.DateOnSaleFromGmt,
                DateOnSaleTo = externalProductResponse.DateOnSaleTo,
                DateOnSaleToGmt = externalProductResponse.DateOnSaleToGmt,
                Status = externalProductResponse.Status,
                Price = externalProductResponse.Price,
                Featured = externalProductResponse.Featured,
                Slug = externalProductResponse.Slug,
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

        private Product ConvertResponseToProductRequest(Product Product)
        {
            Product.Request = new ProductRequest
            {
                Name = Product.Response.Name,
                RegularPrice = Product.Response.RegularPrice,
                Description = Product.Response.Description,
                Type = Product.Response.Type,
                //Status = Product.Response.Status,
                //MetaData = externalProductResponse.MetaData.Select(x =>
                //{
                //    return new ProductMetadata
                //    {
                //        Id = x.Id,
                //        Key = x.Key,
                //        Value = x.Value
                //    };
                //}).ToArray(),
                //Images = externalProductResponse.Images.Select(x =>
                //{
                //    return new Image
                //    {
                //        Id = x.Id,
                //        Name = x.Name,
                //        Src = x.Src,
                //        Alt = x.Alt,
                //        DateCreated = x.DateCreated,
                //        DateCreatedGmt = x.DateCreatedGmt,
                //        DateModified = x.DateModified,
                //        DateModifiedGmt = x.DateModifiedGmt
                //    };
                //}).ToArray()
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
