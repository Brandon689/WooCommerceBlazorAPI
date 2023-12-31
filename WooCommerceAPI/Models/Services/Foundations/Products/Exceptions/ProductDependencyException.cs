using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class ProductDependencyException : Xeption
    {
        public ProductDependencyException(Xeption innerException)
            : base(
                message: "Product dependency error occurred, contact support.",
                   innerException: innerException)
        { }

        public ProductDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
