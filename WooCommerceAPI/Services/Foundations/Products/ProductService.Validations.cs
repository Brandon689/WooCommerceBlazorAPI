using Standard.AI.OpenAI.Models.Services.Foundations.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Services.Foundations.Products.Exceptions;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal partial class ProductService
    {
        private void ValidateProductOnSend(Product Product)
        {
            ValidateProductIsNotNull(Product);

            Validate(
                (Rule: IsInvalid(Product.Request),
                Parameter: nameof(Product.Request)));

            Validate(
                (Rule: IsInvalid(Product.Request.Attributes),
                Parameter: nameof(ProductRequest.Attributes)));

            //Validate(
            //    (Rule: IsInvalid(Product.Request.Attributes),
            //    Parameter: nameof(ProductRequest.Attributes)),

            //    //(Rule: IsInvalid(Product.Request.Model),
            //    //Parameter: nameof(ProductRequest.Model)));
        }

        private void ValidateProductIsNotNull(Product Product)
        {
            if (Product is null)
            {
                throw new NullProductException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidProductException = new InvalidProductException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidProductException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidProductException.ThrowIfContainsErrors();
        }
    }
}
