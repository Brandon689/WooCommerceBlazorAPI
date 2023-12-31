// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions
{
    public class UnauthorizedProductException : Xeption
    {
        public UnauthorizedProductException(Exception innerException)
            : base(
                message: "Unauthorized Product request, fix errors and try again.",
                    innerException: innerException)
        { }

        public UnauthorizedProductException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
