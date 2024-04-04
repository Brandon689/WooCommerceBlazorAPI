using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Models.Services.Foundations.ProductVariations
{
    //public class ProductVariation
    //{
    //    public string RegularPrice { get; set; } = string.Empty;

    //    public string Sku { get; set; } = string.Empty;

    //    public ProductVariationAttribute[] Attributes { get; set; }

    //    public ID Image { get; set; } = null;
    //}

    //public class Links
    //{
    //    public List<Self> self { get; set; }
    //    public List<Collection> collection { get; set; }
    //    public List<Up> up { get; set; }
    //}

    public class ProductVariation
    {
        public int? Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateCreatedGmt { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateModifiedGmt { get; set; }

        public string? Description { get; set; }

        public string? Permalink { get; set; }

        public string? Sku { get; set; }

        public string? Price { get; set; }

        public string? RegularPrice { get; set; }

        public string? SalePrice { get; set; }

        public DateTime? DateOnSaleFrom { get; set; }

        public DateTime? DateOnSaleFromGmt { get; set; }

        public DateTime? DateOnSaleTo { get; set; }

        public DateTime? DateOnSaleToGmt { get; set; }

        public bool? OnSale { get; set; }

        public string? Status { get; set; }

        public bool? Purchasable { get; set; }

        public bool? Virtual { get; set; }

        public bool? Downloadable { get; set; }

        //public List<object> Downloads { get; set; }

        public int? DownloadLimit { get; set; }

        public int? DownloadExpiry { get; set; }

        public string? TaxStatus { get; set; }

        public string? TaxClass { get; set; }

        public bool? ManageStock { get; set; }

        public int? StockQuantity { get; set; }

        public string? StockStatus { get; set; }

        public string? Backorders { get; set; }

        public bool? BackordersAllowed { get; set; }

        public bool? Backordered { get; set; }

        public int? LowStockAmount { get; set; }

        public string? Weight { get; set; }

        public Dimensions? Dimensions { get; set; }

        public string? ShippingClass { get; set; }

        public int? ShippingClassId { get; set; }

        public Image? Image { get; set; }

        public ProductVariationAttribute[]? Attributes { get; set; }

        public int? MenuOrder { get; set; }

        //public List<object> MetaData { get; set; }

        public string? Name { get; set; }

        public int? ParentId { get; set; }

        //public Links Links { get; set; }
    }

    public class Up
    {
        public string href { get; set; }
    }
}
