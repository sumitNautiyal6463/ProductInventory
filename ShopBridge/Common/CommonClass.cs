﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Common
{
    public class CommonClass
    {
        public class UserInfo
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
        }
        public class Search
        {
            public string value { get; set; }
            public bool regex { get; set; }
        }
        public class Column
        {
            public string data { get; set; }
            public string name { get; set; }
            public bool searchable { get; set; }
            public bool orderable { get; set; }
            public Search search { get; set; }
        }
        public class Order
        {
            public int column { get; set; }
            public string dir { get; set; }
        }
    }
}
