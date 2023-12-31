using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class FailedProductServiceException : Xeption
    {
        public FailedProductServiceException(Exception innerException)
            : base(
                message: "Failed Product Service Exception occurred, please contact support for assistance.",
                    innerException: innerException)
        { }

        public FailedProductServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
