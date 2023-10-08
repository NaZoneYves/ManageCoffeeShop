using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Coffee
{
    internal class Food : Product
    {
        private string taste;
        public string Taste { get => taste; set => taste = value; }

        public Food() { }
        public Food(string id, string name, string taste, int quantity) : base(id, name, quantity)
        {
            Taste = taste;
        }


        public override void DisplayMenu()
        {
            Console.WriteLine("---FOOD---");
            //truy vấn
            SqlConnection sqlCon = Connect_DB.Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select a.NameFood, a.TasteFood, b.PriceFood\r\nfrom PRODUCT_FOOD_1 a, PRODUCT_FOOD_2 b\r\nwhere (a.IDFood = b.IDFood)";
            sqlCmd.Connection = sqlCon;

            //nhận kết quả
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                NameProduct = sqlReader.GetString(0);
                Taste = sqlReader.GetString(1);
                PriceProduct = sqlReader.GetInt32(2);

                base.DisplayMenu();
                Console.WriteLine("Taste: " + Taste);
                Console.WriteLine("-----------------------------------------");
            }

            sqlCon.Close();
        }

        public override void DisplayBill()
        {
            base.DisplayBill();
            Console.WriteLine("Taste: " + Taste);
        }
    } 
}
