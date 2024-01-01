namespace WooCommerceAPI.Models.Services.Foundations.ProductVariations
{
    public class ProductVariationsRequest
    {
        public int ProductId { get; set; }
        public F[] Create { get; set; }
    }

    public class F
    {
        public string RegularPrice { get; set; } = string.Empty;

        public A[] Attributes { get; set; }
    }

    public class A
    {
        public int Id { get; set; } = 0;

        public string Option { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
