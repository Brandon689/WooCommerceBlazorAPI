using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Permalink { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateCreatedGmt { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateModifiedGmt { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public bool Featured { get; set; }

        public string CatalogVisibility { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string Sku { get; set; }

        public string Price { get; set; }

        public string RegularPrice { get; set; }

        public string SalePrice { get; set; }

        public object DateOnSaleFrom { get; set; }

        public object DateOnSaleFromGmt { get; set; }

        public object DateOnSaleTo { get; set; }

        public object DateOnSaleToGmt { get; set; }

        public string PriceHtml { get; set; }

        public bool OnSale { get; set; }
    }
}
