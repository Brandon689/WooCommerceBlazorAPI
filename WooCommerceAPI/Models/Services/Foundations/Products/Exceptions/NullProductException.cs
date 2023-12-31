using Xeptions;

namespace WooCommerceAPI.Models.Services.Foundations.Products.Exceptions
{
    public class NullProductException : Xeption
    {
        public NullProductException()
            : base(
                message: "Product is null.")
        { }

        public NullProductException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
