using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class InvalidConfigurationProductException : Xeption
    {
        public InvalidConfigurationProductException(Exception innerException)
            : base(
                message: "Invalid Product configuration error occurred, contact support.",
                    innerException: innerException)
        { }

        public InvalidConfigurationProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
