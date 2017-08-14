using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Crawler_爬虫_.Model
{
    public class Commodity : BaseModel
    {
        public long ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CommodityPrice
    {
        public string id { get; set; }
        public decimal p { get; set; }
        public decimal m { get; set; }
    }
}
