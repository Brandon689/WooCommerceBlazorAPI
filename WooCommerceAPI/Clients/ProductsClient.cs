using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Services.Foundations.Products;
using Xeptions;

namespace WooCommerceAPI.Clients
{
    internal class ProductsClient : IProductsClient
    {
        private readonly IProductService chatCompletionService;

        public ProductsClient(IProductService chatCompletionService) =>
            this.chatCompletionService = chatCompletionService;

        public async ValueTask<Product> SendChatCompletionAsync(Product chatCompletion)
        {
            try
            {
                return await this.chatCompletionService.SendChatCompletionAsync(chatCompletion);
            }
            catch //(ChatCompletionValidationException completionValidationException)
            {
                //throw new ChatCompletionClientValidationException(
                //    completionValidationException.InnerException as Xeption);
                throw;
            }
        }
    }

    //internal class ChatCompletionsClient : IChatCompletionsClient
    //{
    //    private readonly IChatCompletionService chatCompletionService;

    //    public ChatCompletionsClient(IChatCompletionService chatCompletionService) =>
    //        this.chatCompletionService = chatCompletionService;

    //    public async ValueTask<ChatCompletion> SendChatCompletionAsync(ChatCompletion chatCompletion)
    //    {
    //        try
    //        {
    //            return await this.chatCompletionService.SendChatCompletionAsync(chatCompletion);
    //        }
    //        catch (ChatCompletionValidationException completionValidationException)
    //        {
    //            throw new ChatCompletionClientValidationException(
    //                completionValidationException.InnerException as Xeption);
    //        }
    //        catch (ChatCompletionDependencyValidationException completionDependencyValidationException)
    //        {
    //            throw new ChatCompletionClientValidationException(
    //                completionDependencyValidationException.InnerException as Xeption);
    //        }
    //        catch (ChatCompletionDependencyException completionDependencyException)
    //        {
    //            throw new ChatCompletionClientDependencyException(
    //                completionDependencyException.InnerException as Xeption);
    //        }
    //        catch (ChatCompletionServiceException completionServiceException)
    //        {
    //            throw new ChatCompletionClientServiceException(
    //                completionServiceException.InnerException as Xeption);
    //        }
    //    }
    //}
}
