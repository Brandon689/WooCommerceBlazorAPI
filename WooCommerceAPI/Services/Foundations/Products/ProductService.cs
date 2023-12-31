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
        private readonly WooCommerceBroker openAIBroker;

        public ProductService(
            WooCommerceBroker openAIBroker)
        {
            this.openAIBroker = openAIBroker;
        }

        public ValueTask<Product> SendChatCompletionAsync(Product chatCompletion) =>
        TryCatch(async () =>
        {
            //ValidateChatCompletionOnSend(chatCompletion);

            ExternalProductRequest externalChatCompletionRequest =
                ConvertToProductRequest(chatCompletion);
            string f = Newtonsoft.Json.JsonConvert.SerializeObject(externalChatCompletionRequest);
            ExternalProductResponse externalChatCompletionResponse =
                await this.openAIBroker.PostChatCompletionRequestAsync(externalChatCompletionRequest);
            ;
            //return ConvertToChatCompletion(chatCompletion, externalChatCompletionResponse);


            return new Product();

        });

        private static ExternalProductRequest ConvertToProductRequest(Product product)
        {
            return new ExternalProductRequest
            {
                Name = product.Request.Name,
                RegularPrice = product.Request.RegularPrice,
                Description = product.Request.Description,
                Type = product.Request.Type,
                Attributes = product.Request.Attributes.Select(attribute =>
                {
                    return new ExternalProductAttribute
                    {
                        Name = attribute.Name,
                        Variation = attribute.Variation,
                        Options = attribute.Options
                    };
                }).ToArray(),

                //Model = chatCompletion.Request.Model,

                //Messages = chatCompletion.Request.Messages.Select(message =>
                //{
                //    return new ExternalChatCompletionMessage
                //    {
                //        Role = message.Role,
                //        Content = message.Content
                //    };
                //}).ToArray(),

                //Temperature = chatCompletion.Request.Temperature,
                //ProbabilityMass = chatCompletion.Request.ProbabilityMass,
                //CompletionsPerPrompt = chatCompletion.Request.CompletionsPerPrompt,
                //Stream = chatCompletion.Request.Stream,
                //Stop = chatCompletion.Request.Stop,
                //MaxTokens = chatCompletion.Request.MaxTokens,
                //PresencePenalty = chatCompletion.Request.PresencePenalty,
                //FrequencyPenalty = chatCompletion.Request.FrequencyPenalty,
                //LogitBias = chatCompletion.Request.LogitBias,
                //User = chatCompletion.Request.User
            };
        }
    }

    internal partial class ProductService : IProductService
    {
        private delegate ValueTask<Product> ReturningChatCompletionFunction();

        private async ValueTask<Product> TryCatch(ReturningChatCompletionFunction returningChatCompletionFunction)
        {
            try
            {
                return await returningChatCompletionFunction();
            }
            catch
            {
                return null;
            }
            //catch (NullChatCompletionException nullChatCompletionException)
            //{
            //    throw new ChatCompletionValidationException(nullChatCompletionException);
            //}
            //catch (InvalidChatCompletionException invalidChatCompletionException)
            //{
            //    throw new ChatCompletionValidationException(invalidChatCompletionException);
            //}
            //catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            //{
            //    var invalidConfigurationChatCompletionException =
            //        new InvalidConfigurationChatCompletionException(httpResponseUrlNotFoundException);

            //    throw new ChatCompletionDependencyException(invalidConfigurationChatCompletionException);
            //}
            //catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            //{
            //    var unauthorizedChatCompletionException =
            //        new UnauthorizedChatCompletionException(httpResponseUnauthorizedException);

            //    throw new ChatCompletionDependencyException(unauthorizedChatCompletionException);
            //}
            //catch (HttpResponseForbiddenException httpResponseForbiddenException)
            //{
            //    var unauthorizedChatCompletionException =
            //        new UnauthorizedChatCompletionException(httpResponseForbiddenException);

            //    throw new ChatCompletionDependencyException(unauthorizedChatCompletionException);
            //}
            //catch (HttpResponseNotFoundException httpResponseNotFoundException)
            //{
            //    var notFoundChatCompletionException =
            //        new NotFoundChatCompletionException(httpResponseNotFoundException);

            //    throw new ChatCompletionDependencyValidationException(notFoundChatCompletionException);
            //}
            //catch (HttpResponseBadRequestException httpResponseBadRequestException)
            //{
            //    var invalidChatCompletionException =
            //        new InvalidChatCompletionException(httpResponseBadRequestException);

            //    throw new ChatCompletionDependencyValidationException(invalidChatCompletionException);
            //}
            //catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            //{
            //    var excessiveCallChatCompletionException =
            //        new ExcessiveCallChatCompletionException(httpResponseTooManyRequestsException);

            //    throw new ChatCompletionDependencyValidationException(excessiveCallChatCompletionException);
            //}
            //catch (HttpResponseException httpResponseException)
            //{
            //    var failedServerChatCompletionException =
            //        new FailedServerChatCompletionException(httpResponseException);

            //    throw new ChatCompletionDependencyException(failedServerChatCompletionException);
            //}
            //catch (Exception exception)
            //{
            //    var failedChatCompletionServiceException =
            //        new FailedChatCompletionServiceException(exception);

            //    throw new ChatCompletionServiceException(
            //        failedChatCompletionServiceException);
            //}
        }
    }
}
