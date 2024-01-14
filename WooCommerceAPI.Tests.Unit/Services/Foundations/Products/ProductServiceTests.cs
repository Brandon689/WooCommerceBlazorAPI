using KellermanSoftware.CompareNetObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Services.Foundations.Products;

namespace WooCommerceAPI.Tests.Unit.Services.Foundations.Products
{
    public partial class ProductServiceTests
    {
        private readonly Mock<IWooCommerceBroker> WooCommerceBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IProductService productService;

        public ProductServiceTests()
        {
            this.WooCommerceBrokerMock = new Mock<IWooCommerceBroker>();
            this.compareLogic = new CompareLogic();

            this.productService = new ProductService(
                wooCommerceBroker: this.WooCommerceBrokerMock.Object);
        }

        private static dynamic CreateRandomProductProperties(
            DateTimeOffset createdDate,
            int createdDateNumber)
        {
            return new
            {
                Name = GetRandomString(),
                Type = "simple",
                Description = GetRandomString(),
                RegularPrice = GetRandomNumber().ToString(),
                //Messages = GetRandomChatCompletionMessages(),
                //Temperature = GetRandomNumber(),
                //ProbabilityMass = GetRandomNumber(),
                //CompletionsPerPrompt = GetRandomNumber(),
                //Stream = GetRandomBoolean(),
                //Stop = CreateRandomStringArray(),
                //MaxTokens = GetRandomNumber(),
                //PresencePenalty = GetRandomNumber(),
                //FrequencyPenalty = GetRandomNumber(),
                //LogitBias = CreateRandomDictionary(),
                //User = GetRandomString(),
                //Id = GetRandomString(),
                //Object = GetRandomString(),
                //CreatedDate = createdDate,
                //Created = createdDateNumber,
                //Choices = GetRandomChatCompletionChoices(),
                //Usage = GetRandomChatCompletionUsage()
            };
        }

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();

        private static dynamic GetRandomChatCompletionMessage()
        {
            return new
            {
                Role = GetRandomString(),
                Content = GetRandomString()
            };
        }

        private static dynamic GetRandomChatCompletionUsage()
        {
            return new
            {
                PromptTokens = GetRandomNumber(),
                CompletionTokens = GetRandomNumber(),
                TotalTokens = GetRandomNumber()
            };
        }

        private static dynamic[] GetRandomChatCompletionChoices()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
                item => new
                {
                    Index = GetRandomNumber(),
                    Message = GetRandomChatCompletionMessage(),
                    FinishReason = GetRandomString()
                }).ToArray();
        }

        private static dynamic[] GetRandomChatCompletionMessages()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
                item => new
                {
                    Role = GetRandomString(),
                    Content = GetRandomString()
                }).ToArray();
        }
    }
}
