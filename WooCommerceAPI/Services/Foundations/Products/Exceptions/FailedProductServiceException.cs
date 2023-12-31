// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
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
