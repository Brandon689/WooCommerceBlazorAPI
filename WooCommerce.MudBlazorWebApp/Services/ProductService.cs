//using WooCommerceAPI.Models.Services.Foundations.Products;

//namespace WooCommerce.MudBlazorWebApp.Services
//{
//    public class ProductService
//    {
//        private readonly WooCommerceService _wooCommerceService;
//        private Product CurrentProduct { get; set; }

//        public ProductService(WooCommerceService wooCommerceService)
//        {
//            _wooCommerceService = wooCommerceService;
//        }

//        public async Task<Product> GetProductAsync(int id = 0)
//        {
//            if (CurrentProduct == null)
//            {
//                if (id == 0)
//                    return new Product();
//                CurrentProduct = await _wooCommerceService.GetProductAsync(id);
//                return CurrentProduct;
//            }
//            return CurrentProduct;
//        }

//        public Product GetCurrentProduct()
//        {
//            return CurrentProduct;
//        }

//        public void SetCurrentProduct(Product product)
//        {
//            CurrentProduct = product;
//        }
//    }
//}