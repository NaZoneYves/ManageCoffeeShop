using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Coffee
{
    internal class Connect_DB
    {
        public static SqlConnection Connect()
        {
            string strCon = @"Data Source=DESKTOP-LII2CR4\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            return sqlCon;
        }
        
    }
}
