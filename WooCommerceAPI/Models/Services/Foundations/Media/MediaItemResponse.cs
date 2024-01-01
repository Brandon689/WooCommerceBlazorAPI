using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceAPI.Models.Services.Foundations.Media
{
    public class MediaItemResponse
    {
        public int Id { get; set; } = 0;

        public string Src { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Alt { get; set; } = string.Empty;
    }
}
