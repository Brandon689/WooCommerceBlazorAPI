// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
{
    public class NotFoundProductException : Xeption
    {
        public NotFoundProductException(Exception innerException)
            : base(
                message: "Product not found.",
                    innerException: innerException)
        { }

        public NotFoundProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
