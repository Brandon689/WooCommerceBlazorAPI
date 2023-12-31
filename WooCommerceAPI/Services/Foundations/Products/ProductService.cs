using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal partial class ProductService : IProductService
    {
        private readonly IWooCommerceBroker openAIBroker;

        public ProductService(
            IWooCommerceBroker openAIBroker)
        {
            this.openAIBroker = openAIBroker;
        }

        public ValueTask<Product> SendProductAsync(Product Product) =>
        TryCatch(async () =>
        {
            //ValidateProductOnSend(Product);

            ExternalProductRequest externalProductRequest =
                ConvertToProductRequest(Product);
            string f = Newtonsoft.Json.JsonConvert.SerializeObject(externalProductRequest);
            ExternalProductResponse externalProductResponse =
                await this.openAIBroker.PostProductRequestAsync(externalProductRequest);
            
            return ConvertToProduct(Product, externalProductResponse);
        });

        private static ExternalProductRequest ConvertToProductRequest(Product product)
        {
            return new ExternalProductRequest
            {
                Name = product.Request.Name,
                RegularPrice = product.Request.RegularPrice,
                Description = product.Request.Description,
                Type = product.Request.Type,
                //Attributes = product.Request.Attributes.Select(attribute =>
                //{
                //    return new ExternalProductAttribute
                //    {
                //        Name = attribute.Name,
                //        Variation = attribute.Variation,
                //        Options = attribute.Options
                //    };
                //}).ToArray(),

                //Model = Product.Request.Model,

                //Messages = Product.Request.Messages.Select(message =>
                //{
                //    return new ExternalProductMessage
                //    {
                //        Role = message.Role,
                //        Content = message.Content
                //    };
                //}).ToArray(),

                //Temperature = Product.Request.Temperature,
                //ProbabilityMass = Product.Request.ProbabilityMass,
                //CompletionsPerPrompt = Product.Request.CompletionsPerPrompt,
                //Stream = Product.Request.Stream,
                //Stop = Product.Request.Stop,
                //MaxTokens = Product.Request.MaxTokens,
                //PresencePenalty = Product.Request.PresencePenalty,
                //FrequencyPenalty = Product.Request.FrequencyPenalty,
                //LogitBias = Product.Request.LogitBias,
                //User = Product.Request.User
            };
        }

        private Product ConvertToProduct(
            Product Product,
            ExternalProductResponse externalProductResponse)
        {

            Product.Response = new ProductResponse
            {
                Id = externalProductResponse.Id,
                Name = externalProductResponse.Name,
                RegularPrice = externalProductResponse.RegularPrice,
                Description = externalProductResponse.Description,
                Type = externalProductResponse.Type,
                DateCreated = externalProductResponse.DateCreated,
                DateModified = externalProductResponse.DateModified,
                DateModifiedGmt = externalProductResponse.DateModifiedGmt,
                DateOnSaleFrom  = externalProductResponse.DateOnSaleFrom,
                DateOnSaleFromGmt = externalProductResponse.DateOnSaleFromGmt,
                DateOnSaleTo = externalProductResponse.DateOnSaleTo,
                DateOnSaleToGmt = externalProductResponse.DateOnSaleToGmt,
                Status = externalProductResponse.Status,
                Price = externalProductResponse.Price,
                Featured = externalProductResponse.Featured,
                Slug = externalProductResponse.Slug,
                //CreatedDate = this.dateTimeBroker.ConvertToDateTimeOffSet(externalProductResponse.Created),
            };

            return Product;
        }
    }

    internal partial class ProductService : IProductService
    {
        private delegate ValueTask<Product> ReturningProductFunction();

        private async ValueTask<Product> TryCatch(ReturningProductFunction returningProductFunction)
        {
            try
            {
                return await returningProductFunction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ;
                throw;
            }
            //catch (NullProductException nullProductException)
            //{
            //    throw new ProductValidationException(nullProductException);
            //}
            //catch (InvalidProductException invalidProductException)
            //{x
            //    throw new ProductValidationException(invalidProductException);
            //}
            //catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            //{
            //    var invalidConfigurationProductException =
            //        new InvalidConfigurationProductException(httpResponseUrlNotFoundException);

            //    throw new ProductDependencyException(invalidConfigurationProductException);
            //}
            //catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            //{
            //    var unauthorizedProductException =
            //        new UnauthorizedProductException(httpResponseUnauthorizedException);

            //    throw new ProductDependencyException(unauthorizedProductException);
            //}
            //catch (HttpResponseForbiddenException httpResponseForbiddenException)
            //{
            //    var unauthorizedProductException =
            //        new UnauthorizedProductException(httpResponseForbiddenException);

            //    throw new ProductDependencyException(unauthorizedProductException);
            //}
            //catch (HttpResponseNotFoundException httpResponseNotFoundException)
            //{
            //    var notFoundProductException =
            //        new NotFoundProductException(httpResponseNotFoundException);

            //    throw new ProductDependencyValidationException(notFoundProductException);
            //}
            //catch (HttpResponseBadRequestException httpResponseBadRequestException)
            //{
            //    var invalidProductException =
            //        new InvalidProductException(httpResponseBadRequestException);

            //    throw new ProductDependencyValidationException(invalidProductException);
            //}
            //catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            //{
            //    var excessiveCallProductException =
            //        new ExcessiveCallProductException(httpResponseTooManyRequestsException);

            //    throw new ProductDependencyValidationException(excessiveCallProductException);
            //}
            //catch (HttpResponseException httpResponseException)
            //{
            //    var failedServerProductException =
            //        new FailedServerProductException(httpResponseException);

            //    throw new ProductDependencyException(failedServerProductException);
            //}
            //catch (Exception exception)
            //{
            //    var failedProductServiceException =
            //        new FailedProductServiceException(exception);

            //    throw new ProductServiceException(
            //        failedProductServiceException);
            //}
        }
    }
}
