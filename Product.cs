using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    internal class Product
    {
        private string idProduct;
        private string nameProduct;
        private int priceProduct;
        private int quantityProduct;
        
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
        public int PriceProduct { get => priceProduct; set => priceProduct = value; }
        public int QuantityProduct { get => quantityProduct; set => quantityProduct = value; }

        public Product() { }
        public Product(string id, string name, int quantity)
        {
            IdProduct = id;
            NameProduct = name;
            QuantityProduct = quantity;
        }

        public virtual void DisplayMenu()
        {
            Console.WriteLine("Name: " + NameProduct);
            Console.WriteLine("Price: " + PriceProduct);
        }

        public virtual void DisplayBill()
        {
            Console.WriteLine("Name: " + NameProduct);
            Console.WriteLine("Price: " + PriceProduct);
            Console.WriteLine("Quantity: " + QuantityProduct);
        }
    }
}
