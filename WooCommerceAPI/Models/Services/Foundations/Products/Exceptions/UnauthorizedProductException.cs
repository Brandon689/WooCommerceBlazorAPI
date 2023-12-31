using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class UnauthorizedProductException : Xeption
    {
        public UnauthorizedProductException(Exception innerException)
            : base(
                message: "Unauthorized Product request, fix errors and try again.",
                    innerException: innerException)
        { }

        public UnauthorizedProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
