namespace WooCommerce.MudBlazorWebApp.Models
{
    public class ProductV
    {
        public List<ImageV> Images { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }

    public class ImageV
    {
        public string Src { get; set; }
        public string LocalPath { get; set; }
        public int Id { get; set; }
        public bool newImg { get; set; }
    }
}
