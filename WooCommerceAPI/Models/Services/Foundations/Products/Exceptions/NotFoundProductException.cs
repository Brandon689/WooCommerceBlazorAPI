using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class NotFoundProductException : Xeption
    {
        public NotFoundProductException(Exception innerException)
            : base(
                message: "Product not found.",
                    innerException: innerException)
        { }

        public NotFoundProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
