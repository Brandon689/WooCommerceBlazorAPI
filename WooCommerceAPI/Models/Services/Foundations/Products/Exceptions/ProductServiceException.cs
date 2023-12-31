using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class ProductServiceException : Xeption
    {
        public ProductServiceException(Exception innerException)
            : base(
                message: "Product service error occurred, contact support.",
                    innerException: innerException)
        { }

        public ProductServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}