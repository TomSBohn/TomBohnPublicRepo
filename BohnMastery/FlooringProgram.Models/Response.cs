﻿using FlooringProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<OrderInfo> OrderInfo { get; set; }
        public List<ProductInfo> ProductDetails { get; set; }
        public List<StateTaxInfo> StateTaxDetails { get; set; }
    }
}
