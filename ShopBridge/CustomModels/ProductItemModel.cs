using ShopBridge.Common;
using System;
using System.Collections.Generic;

namespace ShopBridge.CustomModels
{
    public class ProductItemModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public CommonClass.Search search { get; set; }
        public List<CommonClass.Column> columns { get; set; }
        public List<CommonClass.Order> order { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
