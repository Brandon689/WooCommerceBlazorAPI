using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Clients.Products;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public interface IWooCommerceClient
    {
        IProductsClient Products { get; }
    }
}
