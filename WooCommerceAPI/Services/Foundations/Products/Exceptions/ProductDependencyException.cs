// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
{
    public class ProductDependencyException : Xeption
    {
        public ProductDependencyException(Xeption innerException)
            : base(
                message: "Product dependency error occurred, contact support.",
                   innerException: innerException)
        { }

        public ProductDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
