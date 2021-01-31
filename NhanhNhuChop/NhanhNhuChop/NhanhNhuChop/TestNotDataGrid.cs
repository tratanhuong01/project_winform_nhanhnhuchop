using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace NhanhNhuChop
{
    public partial class TestNotDataGrid : Form
    {
        SqlConnection conn;
        SqlCommand sqlcmd;
        public TestNotDataGrid()
        {
            InitializeComponent();
        }
        public void connectSQL()
        {
            conn = new SqlConnection();
            String connString = @"Data Source=DESKTOP-9VUDH2B;Initial Catalog=NhanhNhuChop;Integrated Security=True";
            conn.ConnectionString = connString;
        }
        
        private void getThongTin()
        {
            String query = "SELECT IDLichSu,SoCauLienTiep,TongSoCau,SoCauDung,SoCauSai,NgayGioChoi,TienThang,SoGiay FROM LichSuNguoiChoi WHERE IDNguoiChoi = 'NNC0001'";
            sqlcmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                sqlcmd.ExecuteNonQuery();
                SqlDataReader reader = sqlcmd.ExecuteReader();
                String[] idLichSu;
                int[] soCauLienTiep;
                int[] tongSoCau;
                int[] soCauDung;
                int[] soCauSai;
                DateTime[] ngayGioChoi;
                int[] tienThang;
                int[] soGiay;
                idLichSu = new String[15];
                soCauLienTiep = new int[15];
                tongSoCau = new int[15];
                soCauDung = new int[15];
                soCauSai = new int[15];
                ngayGioChoi = new DateTime[15];
                tienThang = new int[15];
                soGiay = new int[15];
                for (int i = 0; i < 15; i++)
                {
                    if (reader.Read())
                    {
                        idLichSu[i] = reader[0].ToString();
                        soCauLienTiep[i] = int.Parse(reader[1].ToString());
                        tongSoCau[i] = int.Parse(reader[2].ToString());
                        soCauDung[i] = int.Parse(reader[3].ToString());
                        soCauSai[i] = int.Parse(reader[4].ToString());
                        ngayGioChoi[i] = (DateTime)reader[5];
                        tienThang[i] = int.Parse(reader[6].ToString());
                        soGiay[i] = int.Parse(reader[7].ToString());
                    }
                }
                for (int i = 0; i < 15 ; i++)
                {
                    button1.Text += idLichSu[i] + "\n\n";
                    button2.Text += Convert.ToString(soCauLienTiep[i]) + "\n\n";
                    button3.Text += Convert.ToString(tongSoCau[i]) + "\n\n";
                    button4.Text += Convert.ToString(soCauDung[i]) + "\n\n";
                    button5.Text += Convert.ToString(soCauSai[i]) + "\n\n";
                    button6.Text += Convert.ToString(ngayGioChoi[i]) + "\n\n";
                    button7.Text += Convert.ToString(soGiay[i]) + "\n\n";
                }
                
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
        }
        private void TestNotDataGrid_Load(object sender, EventArgs e)
        {
            connectSQL();
            getThongTin();
        }
    }
}
