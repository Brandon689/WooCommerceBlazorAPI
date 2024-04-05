namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class TaxLine
    {
        public int? Id { get; set; }

        public string RateCode { get; set; }

        public int? RateId { get; set; }

        public string Label { get; set; }

        public bool? Compound { get; set; }

        public string TaxTotal { get; set; }

        public string ShippingTaxTotal { get; set; }

        public List<object> MetaData { get; set; }
    }
}
