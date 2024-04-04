namespace WooCommerceAPI.Models.Services.Foundations.ProductVariations
{
    public class ProductVariationsRequest
    {
        public int ProductId { get; set; }

        public ProductVariation[] Create { get; set; }
    }
}
