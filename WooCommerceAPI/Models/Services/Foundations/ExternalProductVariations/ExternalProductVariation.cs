﻿using Newtonsoft.Json;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    internal class ExternalProductVariation
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("date_created_gmt")]
        public DateTime? DateCreatedGmt { get; set; }

        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("date_modified_gmt")]
        public DateTime? DateModifiedGmt { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("permalink")]
        public string? Permalink { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("regular_price")]
        public string? RegularPrice { get; set; }

        [JsonProperty("sale_price")]
        public string? SalePrice { get; set; }

        [JsonProperty("date_on_sale_from")]
        public DateTime? DateOnSaleFrom { get; set; }

        [JsonProperty("date_on_sale_from_gmt")]
        public DateTime? DateOnSaleFromGmt { get; set; }

        [JsonProperty("date_on_sale_to")]
        public DateTime? DateOnSaleTo { get; set; }

        [JsonProperty("date_on_sale_to_gmt")]
        public DateTime? DateOnSaleToGmt { get; set; }

        [JsonProperty("on_sale")]
        public bool? OnSale { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("purchasable")]
        public bool? Purchasable { get; set; }

        [JsonProperty("virtual")]
        public bool? Virtual { get; set; }

        [JsonProperty("downloadable")]
        public bool? Downloadable { get; set; }

        //[JsonProperty("downloads")]
        //public List<object> Downloads { get; set; }

        [JsonProperty("download_limit")]
        public int? DownloadLimit { get; set; }

        [JsonProperty("download_expiry")]
        public int? DownloadExpiry { get; set; }

        [JsonProperty("tax_status")]
        public string? TaxStatus { get; set; }

        [JsonProperty("tax_class")]
        public string? TaxClass { get; set; }

        [JsonProperty("manage_stock")]
        public bool? ManageStock { get; set; }

        [JsonProperty("stock_quantity")]
        public int? StockQuantity { get; set; }

        [JsonProperty("stock_status")]
        public string? StockStatus { get; set; }

        [JsonProperty("backorders")]
        public string? Backorders { get; set; }

        [JsonProperty("backorders_allowed")]
        public bool? BackordersAllowed { get; set; }

        [JsonProperty("backordered")]
        public bool? Backordered { get; set; }

        [JsonProperty("low_stock_amount")]
        public int? LowStockAmount { get; set; }

        [JsonProperty("weight")]
        public string? Weight { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions? Dimensions { get; set; }

        [JsonProperty("shipping_class")]
        public string? ShippingClass { get; set; }

        [JsonProperty("shipping_class_id")]
        public int? ShippingClassId { get; set; }

        [JsonProperty("image")]
        public ExternalImage? Image { get; set; }

        [JsonProperty("attributes")]
        public ExternalVariationAttribute[]? Attributes { get; set; }

        [JsonProperty("menu_order")]
        public int? MenuOrder { get; set; }

        //[JsonProperty("meta_data")]
        //public List<object> MetaData { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        //[JsonProperty("_links")]
        //public Links Links { get; set; }
    }

    //public class ExternalProductVariation
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
}
