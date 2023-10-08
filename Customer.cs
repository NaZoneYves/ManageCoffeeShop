using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Coffee
{
    internal class Customer:Person
    {
        private int pointCustomer;
        private float voucherCustomer;

        public int PointCustomer { get => pointCustomer; set => pointCustomer = value; } 
        public float VoucherCustomer { get => voucherCustomer; set => voucherCustomer = value; }

        public Customer()
        {

        }
        public Customer(string id, string name, int point, float vourcher):base(id, name) 
        {
            PointCustomer = point;
            VoucherCustomer = vourcher;
        }

        public Drink OrderDrink()
        {
            Drink item = new Drink();

            SqlConnection sqlCon = Connect_DB.Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            Console.WriteLine("Please Order!");
            sqlCmd.CommandText =
            "select a.NameDrink, b.TypeOfDrink, b.SizeOfDrink, b.PriceOfDrink" +
            "\r\nfrom PRODUCT_DRINK_1 a, PRODUCT_DRINK_2 b\r\n" +
            "where (a.TypeOfDrink = b.TypeOfDrink)\r\n\tand (a.IDDrink = @ID) and (b.SizeOfDrink = @Size)";

            //define parameter @ID, @SizeDrink
            SqlParameter parID = new SqlParameter("@ID", SqlDbType.NChar);
            sqlCmd.Parameters.Add(parID);
            Console.Write("Enter ID of Drink: ");
            parID.Value = Console.ReadLine();

            SqlParameter parSize = new SqlParameter("@Size", SqlDbType.NChar);
            sqlCmd.Parameters.Add(parSize);
            Console.Write("Enter Size of Drink: ");
            parSize.Value = Console.ReadLine();

            Console.Write("Quantity: ");
            item.QuantityProduct = int.Parse(Console.ReadLine());

            sqlCmd.Connection = sqlCon;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            if (sqlReader.Read())
            {
                item.NameProduct = sqlReader.GetString(0);
                item.Type = sqlReader.GetString(1);
                item.Size = sqlReader.GetString(2);
                item.PriceProduct = sqlReader.GetInt32(3);
            }
            else Console.WriteLine("No");
            sqlCon.Close();
            return item;
        }

        public Food OrderFood()
        {
            Food item = new Food();

            SqlConnection sqlCon = Connect_DB.Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            Console.WriteLine("Please Order!");
            sqlCmd.CommandText =
            "select a.NameFood, a.TasteFood, b.PriceFood\r\n" +
            "from PRODUCT_FOOD_1 a, PRODUCT_FOOD_2 b, PRODUCT_FOOD_3 c\r\n" +
            "where (a.IDFood = b.IDFood) and (a.TasteFood = c.TasteFood)\r\n\t" +
            "and ((a.IDFood = @ID) and (c.IDTaste = @Taste))";

            //define parameter @ID, @SizeDrink
            SqlParameter parID = new SqlParameter("@ID", SqlDbType.NChar);
            sqlCmd.Parameters.Add(parID);
            Console.Write("Enter ID of Drink: ");
            parID.Value = Console.ReadLine();

            SqlParameter parTaste = new SqlParameter("@Taste", SqlDbType.NChar);
            sqlCmd.Parameters.Add(parTaste);
            Console.Write("Enter IDTaste of Drink: ");
            parTaste.Value = Console.ReadLine();

            Console.Write("Quantity: ");
            item.QuantityProduct = int.Parse(Console.ReadLine());

            sqlCmd.Connection = sqlCon;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            if (sqlReader.Read())
            {
                item.NameProduct = sqlReader.GetString(0);
                item.Taste = sqlReader.GetString(1);
                item.PriceProduct = sqlReader.GetInt32(2);
            }
            else Console.WriteLine("No");
            sqlCon.Close();
            return item;
        }
        public void Order()
        {
            Bill bill = new Bill();
            bill.Products = new List<Product>();
            string answer2;
            do
            {
                Console.WriteLine("Type of product you want to buy: <1> Drink or <2> Food");
                string answer1 = Console.ReadLine();
                if (answer1 == "1")
                {
                    Drink item = OrderDrink();
                    bill.AddProduct(item);
                }
                else
                {
                    Food item = OrderFood();
                    bill.AddProduct(item);
                }
                Console.WriteLine("Continue? <1> Yes or <0> No");
                answer2 = Console.ReadLine();
            } while (answer2 == "1");

            bill.CalculateTotalMoney();
            bill.DisplayBill();
            Console.WriteLine("Total Money: " + bill.TotalMoney);
        }
    }
}
