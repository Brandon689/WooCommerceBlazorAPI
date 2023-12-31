using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace WooCommerceAPI.Models.Clients.Products.Exceptions
{
    public class ProductClientServiceException : Xeption
    {
        /// <summary>
        /// This exception is thrown when a service error occurs while using the Chat completion client.
        /// For example, if there is a problem with the server or any other service failure.
        /// </summary>
        public ProductClientServiceException(Xeption innerException)
            : base(
                message: "Chat completion client service error occurred, contact support.",
                    innerException: innerException)
        { }

        public ProductClientServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
