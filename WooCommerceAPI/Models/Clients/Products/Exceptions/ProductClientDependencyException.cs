using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace WooCommerceAPI.Models.Clients.Products.Exceptions
{
    public class ProductClientDependencyException : Xeption
    {
        public ProductClientDependencyException(Xeption innerException)
            : base(
                message: "Chat completion dependency error occurred, contact support.",
                    innerException: innerException)
        { }

        public ProductClientDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
