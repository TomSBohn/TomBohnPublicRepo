using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IProductRepo
    {
        List<ProductInfo> GetAllProducts();
    }

    public class ProductRepo : IProductRepo
    {
        private List<ProductInfo> _productInfo;
        public ProductRepo()
        {
            Decode();
        }

        private void Decode()
        {
            _productInfo = new List<ProductInfo>();
            string[] records = File.ReadAllLines(@"textfilereferences\products.txt");

            for (int i = 1; i < records.Length; i++)

            {
                string[] fields = records[i].Split(',');
                ProductInfo temp = new ProductInfo();
                temp.ProductType = Convert.ToString(fields[0]);
                temp.CostPerSquareFoot = Convert.ToDecimal(fields[1]);
                temp.LaborCostPerSquareFoot = Convert.ToDecimal(fields[2]);
                _productInfo.Add(temp);


            }

        }

        public List<ProductInfo> GetAllProducts()
        {
            return _productInfo;
        }
    }
}
