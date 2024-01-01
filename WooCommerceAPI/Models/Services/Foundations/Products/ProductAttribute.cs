namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    public class ProductAttribute
    {
        public int Id { get; set; } = 0;

        public int Position { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public bool Visible { get; set; } = true;

        public bool Variation { get; set; } = false;

        public string[] Options { get; set; } = null;
    }
}
