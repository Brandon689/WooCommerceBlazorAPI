using System.Xml.Linq;
using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Clients.WordPress;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Media;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace FacadeAPI
{
    public class WooCommerceFacade
    {
        private readonly IWooCommerceClient wooCommerceClient;
        private readonly IWordPressClient wordPressClient;

        public WooCommerceFacade(string wcConsumerKey, string wcConsumerSecret, string wcStoreUrl, string wpUser, string wpAppPassword)
        {
            var wooCommerceConfigurations = new WooCommerceConfigurations
            {
                ApiKey = wcConsumerKey,
                ApiSecret = wcConsumerSecret,
                ApiUrl = wcStoreUrl
            };

            var wordPressConfigurations = new WordPressConfigurations
            {
                UserName = wpUser,
                AppPassword = wpAppPassword,
                ApiUrl = wcStoreUrl
            };

            this.wooCommerceClient = new WooCommerceClient(wooCommerceConfigurations);
            this.wordPressClient = new WordPressClient(wordPressConfigurations);
        }
        
        public ProductVariationsRequest hime(SPProduct p)
        {
            ProductVariation[] px = new ProductVariation[p.variants.Length];

            for (int i = 0; i < p.variants.Length; i++)
            {
                ProductVariation v = new();

                v.RegularPrice = p.variants[i].price;
                //v.Image = new WooCommerceAPI.Models.Services.Foundations.Media.MediaItemRequest() { Src = p.images.FirstOrDefault(x => x.id == z.image_id).src };

                var atr = new List<ProductVariationAttribute>();
                atr.Add(new ProductVariationAttribute()
                {
                    Name = p.options[0].name,
                    Option = p.variants[i].option1
                });
                atr.Add(new ProductVariationAttribute()
                {
                    Name = p.options[1].name,
                    Option = p.variants[i].option2
                });
                v.Attributes = atr.ToArray();
                px[i] = v;
            }

            ProductVariationsRequest sourceObject = new ProductVariationsRequest
            {
                Create = px
                //Create = p.variants.Select(z => new ProductVariation()
                //{
                //    RegularPrice = z.price,
                //    Image = new WooCommerceAPI.Models.Services.Foundations.Media.MediaItemRequest() { Src = p.images.FirstOrDefault(x => x.id == z.image_id).src },
                //    //Attributes = p.options.Select(x =>  new ProductVariationAttribute()
                //    //{

                //    //}).ToArray()
                //}).ToArray()

                //new ProductVariation
                //{
                //    RegularPrice = "1500.00",
                //    Attributes = new[]
                //    {
                //        new ProductVariationAttribute { Name = "CCC", Option = "Red" },
                //        new ProductVariationAttribute { Name = "ZZZ", Option = "Small" }
                //    },
                //    Image = new WooCommerceAPI.Models.Services.Foundations.Media.MediaItemRequest() { Id = 50522 }
                //}

            };
            return sourceObject;
        }

        public async Task<Product> prod(SPProduct p)
        {
            await imagereplace03(p);

            var product = new Product
            {
                Request = new ProductRequest
                {
                    Name = p.title,
                    Type = p.variants.Length == 1 ? "simple" : "variable",
                    RegularPrice = p.variants[0].price,
                    Images = p.images.Where(x => x.variant_ids.Length == 0).Select(image => new ProductImage()
                    {
                        Src = image.src
                    }).ToArray(),
                    Attributes = p.options.Select(option => new ProductAttribute()
                    {
                        Name = option.name,
                        Options = option.values,
                        Variation = true
                    }).ToArray(),
                }
            };
            return await imagereplace(product);
        }
        xo a;


        private async Task<SPProduct> imagereplace03(SPProduct p)
        {
            a = new();
            for (int i = 0; i < p.images.Length; i++)
            {
                var file = p.images[i].id.ToString();
                var path = "C:\\2024\\1\\" + file + ".jpg";
                await a.co(p.images[i].src, path);
                p.images[i].src = path;
            }
            return p;
        }

        private async Task<Product> imagereplace0(Product p)
        {
            a = new();
            for (int i = 0; i < p.Request.Images.Length; i++)
            {
                var file = i.ToString(); //p.Request.Images[i].Id.ToString();
                var path = "C:\\2024\\1\\" + file + ".jpg";
                await a.co(p.Request.Images[i].Src, path);
                p.Request.Images[i].Src = path;
            }
            return p;
        }

        private async Task<Product> imagereplace(Product p)
        {
            for (int i = 0; i < p.Request.Images.Length; i++)
            {
                p.Request.Images[i].Src = (await this.wordPressClient.Media.SendMediaItemAsync(new MediaItem()
                {
                    Request = new MediaItemRequest()
                    {
                        Src = p.Request.Images[i].Src
                    }
                })).Response.Src;
            }
            return p;
        }

        public async Task<ProductVariations> yy(ProductVariations y)
        {
            return await this.wooCommerceClient.Products.SendProductVariationsAsync(y);
        }

        public async Task<Product> CreateProductAsync(string name, string type, string regularPrice)
        {
            var product = new Product
            {
                Request = new ProductRequest
                {
                    Name = name,
                    Type = type,
                    RegularPrice = regularPrice,
                    Images = new ProductImage[] { new ProductImage() { Id = 50522 } }
                }
            };

            return await this.wooCommerceClient.Products.SendProductAsync(product);
        }


        public async Task<Product> CreateProductAsync(Product b)
        {

            return await this.wooCommerceClient.Products.SendProductAsync(b);
        }

        // Add more methods here to wrap other operations
    }
}
