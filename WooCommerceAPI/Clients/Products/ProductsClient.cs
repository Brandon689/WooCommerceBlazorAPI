using WooCommerceAPI.Models.Clients.Products.Exceptions;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.Products.Exceptions;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;
using WooCommerceAPI.Services.Foundations.Products;
using Xeptions;

namespace WooCommerceAPI.Clients.Products
{
    internal partial class ProductsClient : IProductsClient
    {
        private readonly IProductService productService;

        public ProductsClient(IProductService productService) =>
            this.productService = productService;

        public async ValueTask<Product> SendProductAsync(Product product)
        {
            try
            {
                return await productService.SendProductAsync(product);
            }
            catch (ProductValidationException completionValidationException)
            {
                throw new ProductClientValidationException(
                    completionValidationException.InnerException as Xeption);
            }
            catch (ProductDependencyValidationException completionDependencyValidationException)
            {
                throw new ProductClientValidationException(
                    completionDependencyValidationException.InnerException as Xeption);
            }
            catch (ProductDependencyException completionDependencyException)
            {
                throw new ProductClientDependencyException(
                    completionDependencyException.InnerException as Xeption);
            }
            catch (ProductServiceException completionServiceException)
            {
                throw new ProductClientServiceException(
                    completionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations product)
        {
            try
            {
                return await productService.SendProductVariationsAsync(product);
            }
            catch (ProductValidationException completionValidationException)
            {
                throw new ProductClientValidationException(
                    completionValidationException.InnerException as Xeption);
            }
            catch (ProductDependencyValidationException completionDependencyValidationException)
            {
                throw new ProductClientValidationException(
                    completionDependencyValidationException.InnerException as Xeption);
            }
            catch (ProductDependencyException completionDependencyException)
            {
                throw new ProductClientDependencyException(
                    completionDependencyException.InnerException as Xeption);
            }
            catch (ProductServiceException completionServiceException)
            {
                throw new ProductClientServiceException(
                    completionServiceException.InnerException as Xeption);
            }
        }
    }
}
