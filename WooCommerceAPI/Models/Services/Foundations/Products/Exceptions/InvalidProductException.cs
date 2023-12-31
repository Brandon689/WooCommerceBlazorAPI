using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class InvalidProductException : Xeption
    {
        public InvalidProductException()
            : base(
                message: "Product is invalid.")
        { }

        public InvalidProductException(Exception innerException)
            : base(
                message: "Product is invalid.",
                    innerException: innerException)
        { }

        public InvalidProductException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
