using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class ExcessiveCallProductException : Xeption
    {
        public ExcessiveCallProductException(Exception innerException)
            : base(
                message: "Excessive call error occurred, limit your calls.",
                    innerException: innerException)
        { }

        public ExcessiveCallProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
