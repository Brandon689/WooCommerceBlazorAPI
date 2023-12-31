using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public string Type { get; set; } = "simple";

        public string Description { get; set; } = string.Empty;

        public string RegularPrice { get; set; } = string.Empty;

        public ProductAttribute[] Attributes { get; set; } = null;
    }

    public class ProductAttribute
    {
        public string Name { get; set; }

        public bool Visible { get; set; } = true;

        public bool Variation { get; set; }

        public string[] Options { get; set; }
    }
}
