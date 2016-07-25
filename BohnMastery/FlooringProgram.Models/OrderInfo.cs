using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class OrderInfo : IEnumerable
    {
        public OrderInfo()
        {
           // ProductType = new ProductInfo();
        }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int OrderID { get; set; }
        public decimal Area { get; set; }
        public decimal Total { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public string State { get; set; }
        public ProductInfo ProductType { get; set; }
        public StateTaxInfo Tax { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
