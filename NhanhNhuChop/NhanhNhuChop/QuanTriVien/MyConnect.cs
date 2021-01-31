using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace QuanTriVien
{
    
    class MyConnect
    {
        public SqlConnection conn;
        public String connectString = @"Data Source=DESKTOP-9VUDH2B;Initial Catalog=NhanhNhuChop;Integrated Security=True";
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
