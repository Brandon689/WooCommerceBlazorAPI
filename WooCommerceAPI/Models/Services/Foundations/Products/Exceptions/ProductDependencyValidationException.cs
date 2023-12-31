using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class ProductDependencyValidationException : Xeption
    {
        public ProductDependencyValidationException(Xeption innerException)
            : base(
                message: "Product dependency validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public ProductDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
