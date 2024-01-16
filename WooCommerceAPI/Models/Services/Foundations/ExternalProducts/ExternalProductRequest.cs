﻿using Newtonsoft.Json;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProducts
{
    internal class ExternalProductRequest
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; } = "simple";

        [JsonProperty("description")]
        public string? Description { get; set; } = string.Empty;

        [JsonProperty("regular_price")]
        public string? RegularPrice { get; set; } = string.Empty;

        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalProductAttribute[] Attributes { get; set; } = null;

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalID[] Images { get; set; }

        [JsonProperty("meta_data", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalProductMetadata[] Metadata { get; set; }




        [JsonProperty("slug")]
        public string? Slug { get; set; }

        //[JsonProperty("permalink")]
        //public string? Permalink { get; set; }

        //[JsonProperty("date_created", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime DateCreated { get; set; }

        //[JsonProperty("date_created_gmt", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime DateCreatedGmt { get; set; }

        //[JsonProperty("date_modified", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime DateModified { get; set; }

        //[JsonProperty("date_modified_gmt", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime DateModifiedGmt { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("featured")]
        public bool? Featured { get; set; }

        [JsonProperty("catalog_visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string? CatalogVisibility { get; set; }

        [JsonProperty("short_description")]
        public string? ShortDescription { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        //[JsonProperty("price")]
        //public string? Price { get; set; }

        //[JsonProperty("sale_price")]
        //public string? SalePrice { get; set; }

        ////[JsonProperty("date_on_sale_from")]
        ////public object DateOnSaleFrom { get; set; }

        ////[JsonProperty("date_on_sale_from_gmt")]
        ////public object DateOnSaleFromGmt { get; set; }

        ////[JsonProperty("date_on_sale_to")]
        ////public object DateOnSaleTo { get; set; }

        ////[JsonProperty("date_on_sale_to_gmt")]
        ////public object DateOnSaleToGmt { get; set; }

        //[JsonProperty("price_html")]
        //public string? PriceHtml { get; set; }

        //[JsonProperty("on_sale")]
        //public bool? OnSale { get; set; }

        //[JsonProperty("purchasable")]
        //public bool? Purchasable { get; set; }

        ////[JsonProperty("total_sales")]
        ////public int TotalSales { get; set; }

        ////[JsonProperty("virtual")]
        ////public bool Virtual { get; set; }

        ////[JsonProperty("downloadable")]
        ////public bool Downloadable { get; set; }

        ////[JsonProperty("downloads")]
        ////public List<object> Downloads { get; set; }

        //[JsonProperty("download_limit")]
        //public int? DownloadLimit { get; set; }

        //[JsonProperty("download_expiry")]
        //public int? DownloadExpiry { get; set; }

        //[JsonProperty("external_url")]
        //public string? ExternalUrl { get; set; }

        //[JsonProperty("button_text")]
        //public string? ButtonText { get; set; }

        //[JsonProperty("tax_status")]
        //public string? TaxStatus { get; set; }

        //[JsonProperty("tax_class")]
        //public string? TaxClass { get; set; }

        [JsonProperty("manage_stock")]
        public bool? ManageStock { get; set; }

        [JsonProperty("stock_quantity")]
        public int? StockQuantity { get; set; }

        [JsonProperty("stock_status")]
        public string? StockStatus { get; set; }

        //[JsonProperty("backorders")]
        //public string Backorders { get; set; }

        //[JsonProperty("backorders_allowed")]
        //public bool BackordersAllowed { get; set; }

        //[JsonProperty("backordered")]
        //public bool Backordered { get; set; }

        //[JsonProperty("sold_individually")]
        //public bool SoldIndividually { get; set; }

        //[JsonProperty("weight")]
        //public string Weight { get; set; }

        //[JsonProperty("dimensions")]
        //public Dimensions Dimensions { get; set; }

        //[JsonProperty("shipping_required")]
        //public bool ShippingRequired { get; set; }

        //[JsonProperty("shipping_taxable")]
        //public bool ShippingTaxable { get; set; }

        //[JsonProperty("shipping_class")]
        //public string ShippingClass { get; set; }

        //[JsonProperty("shipping_class_id")]
        //public int ShippingClassId { get; set; }

        //[JsonProperty("reviews_allowed")]
        //public bool ReviewsAllowed { get; set; }

        //[JsonProperty("average_rating")]
        //public string AverageRating { get; set; }

        //[JsonProperty("rating_count")]
        //public int RatingCount { get; set; }

        //[JsonProperty("related_ids")]
        //public List<int> RelatedIds { get; set; }

        //[JsonProperty("upsell_ids")]
        //public List<object> UpsellIds { get; set; }

        //[JsonProperty("cross_sell_ids")]
        //public List<object> CrossSellIds { get; set; }

        //[JsonProperty("parent_id")]
        //public int ParentId { get; set; }

        //[JsonProperty("purchase_note")]
        //public string PurchaseNote { get; set; }

        //[JsonProperty("categories")]
        //public List<Category> Categories { get; set; }

        //[JsonProperty("tags")]
        //public List<object> Tags { get; set; }

        ////[JsonProperty("images")]
        ////public ExternalImage[] Images { get; set; }

        ////[JsonProperty("attributes")]
        ////public ExternalProductAttribute[] Attributes { get; set; }

        //[JsonProperty("default_attributes")]
        //public DefaultAttribute[] DefaultAttributes { get; set; }

        //[JsonProperty("variations")]
        //public List<object> Variations { get; set; }

        //[JsonProperty("grouped_products")]
        //public List<object> GroupedProducts { get; set; }

        //[JsonProperty("menu_order")]
        //public int MenuOrder { get; set; }

        //[JsonProperty("meta_data")]
        //public List<ExternalProductMetadata> MetaData { get; set; }

        //[JsonProperty("_links")]
        //public Links Links { get; set; }
    }
}