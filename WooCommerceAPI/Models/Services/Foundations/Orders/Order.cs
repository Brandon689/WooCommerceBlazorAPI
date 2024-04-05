namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class Order
    {
        public int? Id { get; set; }

        public int? ParentId { get; set; }

        public string? Number { get; set; }

        public string? SetPaid { get; set; }

        public string? OrderKey { get; set; }

        public string? CreatedVia { get; set; }

        public string? Version { get; set; }

        public string? Status { get; set; }

        public string? Currency { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateCreatedGmt { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateModifiedGmt { get; set; }

        public string? DiscountTotal { get; set; }

        public string? DiscountTax { get; set; }

        public string? ShippingTotal { get; set; }

        public string? ShippingTax { get; set; }

        public string? CartTax { get; set; }

        public string? Total { get; set; }

        public string? TotalTax { get; set; }

        public bool? PricesIncludeTax { get; set; }

        public int? CustomerId { get; set; }

        public string? CustomerIpAddress { get; set; }

        public string? CustomerUserAgent { get; set; }

        public string? CustomerNote { get; set; }

        public Billing? Billing { get; set; }

        public Shipping? Shipping { get; set; }

        public string? PaymentMethod { get; set; }

        public string? PaymentMethodTitle { get; set; }

        public string? TransactionId { get; set; }

        public DateTime? DatePaid { get; set; }

        public DateTime? DatePaidGmt { get; set; }

        public DateTime? DateCompleted { get; set; }

        public DateTime? DateCompletedGmt { get; set; }

        public string? CartHash { get; set; }

        public List<MetaData>? MetaData { get; set; }

        public LineItem[]? LineItems { get; set; }

        public List<TaxLine>? TaxLines { get; set; }

        public List<ShippingLine>? ShippingLines { get; set; }

        public List<object>? FeeLines { get; set; }

        public List<object>? CouponLines { get; set; }

        public List<object>? Refunds { get; set; }

        //[JsonProperty("_links")]
        //public Links Links { get; set; }
    }
}
