using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class Order
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("order_key")]
        public string OrderKey { get; set; }

        [JsonProperty("created_via")]
        public string CreatedVia { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("date_created_gmt")]
        public DateTime? DateCreatedGmt { get; set; }

        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("date_modified_gmt")]
        public DateTime? DateModifiedGmt { get; set; }

        [JsonProperty("discount_total")]
        public string DiscountTotal { get; set; }

        [JsonProperty("discount_tax")]
        public string DiscountTax { get; set; }

        [JsonProperty("shipping_total")]
        public string ShippingTotal { get; set; }

        [JsonProperty("shipping_tax")]
        public string ShippingTax { get; set; }

        [JsonProperty("cart_tax")]
        public string CartTax { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("prices_include_tax")]
        public bool? PricesIncludeTax { get; set; }

        [JsonProperty("customer_id")]
        public int? CustomerId { get; set; }

        [JsonProperty("customer_ip_address")]
        public string CustomerIpAddress { get; set; }

        [JsonProperty("customer_user_agent")]
        public string CustomerUserAgent { get; set; }

        [JsonProperty("customer_note")]
        public string CustomerNote { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("payment_method_title")]
        public string PaymentMethodTitle { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("date_paid")]
        public DateTime? DatePaid { get; set; }

        [JsonProperty("date_paid_gmt")]
        public DateTime? DatePaidGmt { get; set; }

        [JsonProperty("date_completed")]
        public object DateCompleted { get; set; }

        [JsonProperty("date_completed_gmt")]
        public object DateCompletedGmt { get; set; }

        [JsonProperty("cart_hash")]
        public string CartHash { get; set; }

        [JsonProperty("meta_data")]
        public List<MetaData> MetaData { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("fee_lines")]
        public List<object> FeeLines { get; set; }

        [JsonProperty("coupon_lines")]
        public List<object> CouponLines { get; set; }

        [JsonProperty("refunds")]
        public List<object> Refunds { get; set; }

        //[JsonProperty("_links")]
        //public Links Links { get; set; }
    }
}
