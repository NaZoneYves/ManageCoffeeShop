using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    internal class Bill
    {
        private List<Product> products;
        private string idBill;
        private int totalMoney;

        public List<Product> Products { get => products; set => products = value; }
        public string IdBill { get => idBill; set => idBill = value; }
        public int TotalMoney { get => totalMoney; set => totalMoney = value; }

        public Bill() 
        { 
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void DisplayBill()
        {
            Console.WriteLine("---BILL---");
            foreach (var item in Products)
            {
                item.DisplayBill();
            }
        }

        public void CalculateTotalMoney()
        {
            foreach (var item in Products)
            {
                TotalMoney = TotalMoney + (item.PriceProduct*item.QuantityProduct);
            }
        }
    }
}
