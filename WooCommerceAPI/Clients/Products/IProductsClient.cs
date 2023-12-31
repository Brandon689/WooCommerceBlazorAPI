using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Clients.Products
{
    public interface IProductsClient
    {
        ValueTask<Product> SendProductAsync(Product Product);
    }
}
