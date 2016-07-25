using System.Collections.Generic;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class ProductResponse
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public List<ProductInfo> Data { get; set; }
    }
}