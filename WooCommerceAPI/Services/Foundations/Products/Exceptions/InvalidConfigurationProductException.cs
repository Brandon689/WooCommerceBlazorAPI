// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
{
    public class InvalidConfigurationProductException : Xeption
    {
        public InvalidConfigurationProductException(Exception innerException)
            : base(
                message: "Invalid Product configuration error occurred, contact support.",
                    innerException: innerException)
        { }

        public InvalidConfigurationProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
