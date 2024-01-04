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
            ValidateProductOnSend(product);

            ExternalProductRequest externalProductRequest = ConvertToProductRequest(product);
            //string f = Newtonsoft.Json.JsonConvert.SerializeObject(externalProductRequest);
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









        private static ExternalProductRequest ConvertToProductRequest(Product product)
        {
            return new ExternalProductRequest
            {
                Name = product.Request.Name,
                RegularPrice = product.Request.RegularPrice,
                Description = product.Request.Description,
                Type = product.Request.Type,
                Attributes = product.Request.Attributes.Select(attribute =>
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
                }).ToArray(),
                Images = product.Request.Images.Select(message =>
                {
                    return new ExternalImage
                    {
                        Id = message.Id
                    };
                }).ToArray(),
            };
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
                            }).ToArray()
                    }).ToArray()
            };
        }
    }
}
