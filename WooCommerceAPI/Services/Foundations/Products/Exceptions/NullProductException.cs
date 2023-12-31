using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace WooCommerceAPI.Services.Foundations.Products.Exceptions
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
