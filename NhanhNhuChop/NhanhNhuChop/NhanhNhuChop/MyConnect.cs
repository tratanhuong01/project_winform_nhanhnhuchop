using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace NhanhNhuChop
{
    
    class MyConnect
    {
        public SqlConnection conn;
        public String connectString = @"Data Source=DESKTOP-9VUDH2B\SQLEXPRESS;Initial Catalog=NhanhNhuChop;Integrated Security=True";
        public void Connect()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connectString;
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
        }
    }
}
