using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.CustomModels
{
    public class ViewProductItemResponse
    {
        public List<ViewProductItem> ViewProductItemList { get; set; } = new List<ViewProductItem>();
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
    public class ViewProductItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
