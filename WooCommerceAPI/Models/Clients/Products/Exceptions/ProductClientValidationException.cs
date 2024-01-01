using Xeptions;

namespace WooCommerceAPI.Models.Clients.Products.Exceptions
{
    public class ProductClientValidationException : Xeption
    {
        /// <summary>
        /// This exception is thrown when a validation error occurs while using the Product client.
        /// For example, if required data is missing or invalid.
        /// </summary>
        public ProductClientValidationException(Xeption innerException)
            : base(
                message: "Chat completion client validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public ProductClientValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
