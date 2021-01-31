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
    public partial class LichSuNguoiDung : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private String id;
        private String ten;
        public LichSuNguoiDung()
        {
            InitializeComponent();
        }
        public LichSuNguoiDung(String ten , String id)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
        }
        private void LichSuNguoiDung_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            hienThi();
        }
        private void hienThi()
        {
            String query = "SELECT IDLichSu,SoCauLienTiep,TongSoCau,SoCauDung,SoCauSai,NgayGioChoi,TienThang,SoGiay FROM LichSuNguoiChoi WHERE IDNguoiChoi = @id ORDER BY NgayGioChoi DESC";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlapdap = new SqlDataAdapter(sqlcmd);
                DataTable data = new DataTable();
                sqlapdap.Fill(data);
                connect.conn.Close();
                dataGridView1.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Thất bại");
                ex.ToString();
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new TrangChu(this.ten, this.id);
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }
    }
}
