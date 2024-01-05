namespace FacadeAPI
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Image
    {
        public long id { get; set; }
        public long product_id { get; set; }
        public int position { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string alt { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string src { get; set; }
        public long[] variant_ids { get; set; }

        public int wordpress_id { get; set; }

    }

    public class Option
    {
        public long id { get; set; }
        public long product_id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public string[] values { get; set; }
    }

    public class SPProduct
    {
        public long id { get; set; }
        public string title { get; set; }
        public string body_html { get; set; }
        public string vendor { get; set; }
        public string product_type { get; set; }
        public DateTime created_at { get; set; }
        public string handle { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime published_at { get; set; }
        public string template_suffix { get; set; }
        public string published_scope { get; set; }
        public string tags { get; set; }
        public Variant[] variants { get; set; }
        public Option[] options { get; set; }
        public Image[] images { get; set; }
        public Image image { get; set; }
    }

    public class ShopifyProduct
    {
        public SPProduct product { get; set; }
    }

    public class Variant
    {
        public long id { get; set; }
        public long product_id { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string sku { get; set; }
        public int position { get; set; }
        public string compare_at_price { get; set; }
        public string fulfillment_service { get; set; }
        public string inventory_management { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool taxable { get; set; }
        public string barcode { get; set; }
        public int grams { get; set; }
        public long image_id { get; set; }
        public double weight { get; set; }
        public string weight_unit { get; set; }
        public bool requires_shipping { get; set; }
    }


}
