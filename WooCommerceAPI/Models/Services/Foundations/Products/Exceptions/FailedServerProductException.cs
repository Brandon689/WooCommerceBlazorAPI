using Xeptions;

namespace WooCommerceAPI.Services.Foundations.Products.Exceptions
{
    public class FailedServerProductException : Xeption
    {
        public FailedServerProductException(Exception innerException)
            : base(
                message: "Failed Product server error occurred, contact support.",
                    innerException: innerException)
        { }

        public FailedServerProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}