using Newtonsoft.Json;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Product
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; } = "simple";

        public string? Description { get; set; }

        public string? RegularPrice { get; set; }

        public ProductAttribute[]? Attributes { get; set; }

        public Image[]? Images { get; set; }

        public ProductMetadata[]? MetaData { get; set; }

        public string? Slug { get; set; }

        public string? Permalink { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateCreatedGmt { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateModifiedGmt { get; set; }

        public string? Status { get; set; }

        public bool? Featured { get; set; }

        public string? CatalogVisibility { get; set; }

        public string? ShortDescription { get; set; }

        public string? Sku { get; set; }

        public string? Price { get; set; }

        public string? SalePrice { get; set; }

        public DateTime? DateOnSaleFrom { get; set; }

        public DateTime? DateOnSaleFromGmt { get; set; }

        public DateTime? DateOnSaleTo { get; set; }

        public DateTime? DateOnSaleToGmt { get; set; }

        public string? PriceHtml { get; set; }

        public bool? OnSale { get; set; }

        public bool? Purchasable { get; set; }

        public int? TotalSales { get; set; }

        public bool? Virtual { get; set; }

        public bool? Downloadable { get; set; }

        //public List<object> Downloads { get; set; }

        //public int DownloadLimit { get; set; }

        //public int DownloadExpiry { get; set; }

        public string? ExternalUrl { get; set; }

        public string? ButtonText { get; set; }

        public string? TaxStatus { get; set; }

        public string? TaxClass { get; set; }

        public bool? ManageStock { get; set; }

        public int? StockQuantity { get; set; }

        public string? StockStatus { get; set; }

        public string? Backorders { get; set; }

        public bool? BackordersAllowed { get; set; }

        public bool? Backordered { get; set; }

        public bool? SoldIndividually { get; set; }

        public string? Weight { get; set; }

        public Dimensions Dimensions { get; set; }

        public bool? ShippingRequired { get; set; }

        public bool? ShippingTaxable { get; set; }

        public string? ShippingClass { get; set; }

        public int? ShippingClassId { get; set; }

        public bool? ReviewsAllowed { get; set; }

        public string? AverageRating { get; set; }

        public int? RatingCount { get; set; }

        //public List<int> RelatedIds { get; set; }

        //public List<object> UpsellIds { get; set; }

        public List<object> CrossSellIds { get; set; }

        public int? ParentId { get; set; }

        public string? PurchaseNote { get; set; }

        public Category[]? Categories { get; set; }

        //public List<object> Tags { get; set; }

        //public ProductAttribute[] Attributes { get; set; }

        //public DefaultAttribute[] DefaultAttributes { get; set; }

        //public List<object> Variations { get; set; }

        //public List<object> GroupedProducts { get; set; }

        public int? MenuOrder { get; set; }

        public Links Links { get; set; }

    }
}
