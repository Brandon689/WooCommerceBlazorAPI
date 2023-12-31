// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
{
    public class InvalidProductException : Xeption
    {
        public InvalidProductException()
            : base(
                message: "Product is invalid.")
        { }

        public InvalidProductException(Exception innerException)
            : base(
                message: "Product is invalid.",
                    innerException: innerException)
        { }

        public InvalidProductException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
