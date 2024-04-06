namespace WooCommerceAPI.Models.Services.Foundations.Settings
{
    public class Setting
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public string ParentId { get; set; }

        public string[] SubGroups { get; set; }

        //public Links Links { get; set; }
    }
}
