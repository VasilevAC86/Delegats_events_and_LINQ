﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegats_events_and_LINQ
{
    public class Order
    {
        public int Num { get; set; }
        public string Customer {  get; set; }
        public List<OrderProduct> Products { get; set; }       
    }
}
