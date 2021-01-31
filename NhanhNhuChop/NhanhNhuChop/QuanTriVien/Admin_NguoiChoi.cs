using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanTriVien
{
    public partial class Admin_NguoiChoi : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private int num1;
        private int num2;
        private int num3;
        String query1 = "SELECT * FROM ThongTinCaNhan WHERE Ten = @a";
        String query2 = "SELECT * FROM ThongTinCaNhan WHERE IDNguoiChoi = @a";
        String query3 = "SELECT * FROM ThongTinCaNhan WHERE TenDangNhap = @a";
        String[] query;
        RadioButton[] radio;
        public Admin_NguoiChoi()
        {
            InitializeComponent();
        }
        private int LaySoTaiKhoanDaTao()
        {
            String query = "SELECT COUNT(*) FROM TaiKhoanNguoiDung ";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                num1 = (int)sqlcmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return num1;
        }
        private int LaySoTaiKhoanDaThamGiaChoi()
        {
            String query = "SELECT DISTINCT LichSuNguoiChoi.IDNguoiChoi FROM LichSuNguoiChoi INNER JOIN  TaiKhoanNguoiDung " +
            " ON TaiKhoanNguoiDung.IDNguoiChoi = TaiKhoanNguoiDung.IDNguoiChoi WHERE LichSuNguoiChoi.IDNguoiChoi = TaiKhoanNguoiDung.IDNguoiChoi";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
                SqlDataReader rs = sqlcmd.ExecuteReader();
                while (rs.Read())
                {
                    num2++;
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return num2;
        }
        private int LaySoTaiKhoanChuaCapNhatThongTin()
        {
            String query = "SELECT IDNguoiChoi FROM ThongTinCaNhan WHERE Ho IS NULL AND Ten IS NULL AND GioiTinh IS NULL " +
        " AND NgaySinh IS NULL AND DiaChi IS NULL AND Email IS NULL AND SoDienThoai IS NULL ";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
                SqlDataReader rs = sqlcmd.ExecuteReader();
                while (rs.Read())
                {
                    num3++;
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return num3;
        }
        private void timKiemThongTin(String query,String para)
        {
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@a", SqlDbType.NVarChar);
            sqlcmd.Parameters["@a"].Value = para;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter sqlapdap = new SqlDataAdapter(sqlcmd);
                DataTable data = new DataTable();
                sqlapdap.Fill(data);
                connect.conn.Close();
                dataGridView1.DataSource = data;
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
        }
        private void hienThi()
        {
            String query = "SELECT * FROM TaiKhoanNguoiDung LEFT JOIN  ThongTinCaNhan" +
            " ON TaiKhoanNguoiDung.IDNguoiChoi = ThongTinCaNhan.IDNguoiChoi";
            sqlcmd = new SqlCommand(query, connect.conn);
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
                ex.ToString();
            }
        }
        private void hienThiNguoiChoi()
        {
            String query = "SELECT CONCAT(TaiKhoanNguoiDung.TenDangNhap , N'  Đã Chơi Lúc ' ,CONVERT(NVARCHAR, NgayGioChoi, 20)) N'Lịch Sử Người Chơi' FROM LichSuNguoiChoi " +
" INNER JOIN TaiKhoanNguoiDung ON TaiKhoanNguoiDung.IDNguoiChoi = LichSuNguoiChoi.IDNguoiChoi ORDER BY NgayGioChoi DESC";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
                sqlcmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlapdap = new SqlDataAdapter(sqlcmd);
                DataTable data = new DataTable();
                sqlapdap.Fill(data);
                connect.conn.Close();
                dataGridView3.DataSource = data;
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
        }
        private void Admin_NguoiChoi_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            num_1.Text = Convert.ToString(LaySoTaiKhoanDaTao());
            num_2.Text = Convert.ToString(LaySoTaiKhoanDaThamGiaChoi());
            num_3.Text = Convert.ToString(LaySoTaiKhoanChuaCapNhatThongTin());
            hienThi();
            hienThiNguoiChoi();
        }

        private void btnCauHoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new Admin_CauHoi();
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }

        private void btnTienThuong_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new Admin_TienThuong();
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hienThiNguoiChoi();
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            radio = new RadioButton[] { rabtn0, rabtn1, rabtn2 };
            query = new String[] { query1, query2, query3 };
            for (int i = 0; i < radio.Length; i++)
            {
                if (radio[i].Checked)
                {
                    txtTimKiem.Enabled = true;
                }
               
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < radio.Length; i++)
            {
                timKiemThongTin(query[i], txtTimKiem.Text);
            }
        }
    }
}
