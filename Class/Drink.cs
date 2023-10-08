using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    internal class Drink:Product
    {
        private string size;
        private string type;

        public string Size { get => size; set => size = value; }
        public string Type { get => type; set => type = value; }

        public Drink() { }
        public Drink(string id, string name, string size, string type, int quantity) : base(id, name, quantity)
        {
            Size = size;
            Type = type;
        }

        public override void DisplayMenu()
        {
            Console.WriteLine("---DRINK---");

            //truy vấn
            SqlConnection sqlCon = Connect_DB.Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select a.TypeOfDrink, a.NameDrink,  b.SizeOfDrink, b.PriceOfDrink\r\nfrom PRODUCT_DRINK_1 a, PRODUCT_DRINK_2 b\r\nwhere (a.TypeOfDrink = b.TypeOfDrink)";
            sqlCmd.Connection = sqlCon;

            //nhận kết quả
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                Type = sqlReader.GetString(0);
                NameProduct = sqlReader.GetString(1);
                Size = sqlReader.GetString(2);
                PriceProduct = sqlReader.GetInt32(3);

                base.DisplayMenu();
                Console.WriteLine("Type: " + Type);
                Console.WriteLine("Size: " + Size);
                Console.WriteLine("-----------------------------------------");
            }
            sqlCon.Close();
        }

        public override void DisplayBill()
        {
            base.DisplayBill();
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Size: " + Size);
        }
    }
}
