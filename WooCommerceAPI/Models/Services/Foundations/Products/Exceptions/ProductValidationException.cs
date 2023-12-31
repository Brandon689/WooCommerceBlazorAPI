using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class ProductValidationException : Xeption
    {
        public ProductValidationException(Xeption innerException)
            : base(
                message: "Product validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public ProductValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
