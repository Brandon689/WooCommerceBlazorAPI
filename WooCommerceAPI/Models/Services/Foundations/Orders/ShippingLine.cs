namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class ShippingLine
    {
        public int? Id { get; set; }

        public string MethodTitle { get; set; }

        public string MethodId { get; set; }

        public string Total { get; set; }

        public string TotalTax { get; set; }

        public List<object> Taxes { get; set; }

        public List<object> MetaData { get; set; }
    }
}
