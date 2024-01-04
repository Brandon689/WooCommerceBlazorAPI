using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Models.Services.Foundations.ProductVariations
{
    public class ProductVariationsRequest
    {
        public int ProductId { get; set; }
        public ProductVariation[] Create { get; set; }
    }

    public class ProductVariation
    {
        public string RegularPrice { get; set; } = string.Empty;

        public ProductVariationAttribute[] Attributes { get; set; }

        public MediaItemRequest Image { get; set; } = null;
    }

    public class ProductVariationAttribute
    {
        public int Id { get; set; } = 0;

        public string Option { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
