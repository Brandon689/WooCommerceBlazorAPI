// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
{
    public class ProductServiceException : Xeption
    {
        public ProductServiceException(Exception innerException)
            : base(
                message: "Product service error occurred, contact support.",
                    innerException: innerException)
        { }

        public ProductServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}