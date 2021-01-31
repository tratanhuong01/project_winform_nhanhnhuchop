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
    public partial class Admin_TienThuong : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private int num1;
        private int num2;
        private int num3;
        public Admin_TienThuong()
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
        private void hienThi()
        {
            String query = "SELECT * FROM TienThuong ";
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
            connect.conn.Close();
        }
        private void hienThiNguoiChoi()
        {
            String query = "SELECT CONCAT(TaiKhoanNguoiDung.TenDangNhap , N'  Đã Chơi Lúc ' ,CONVERT(NVARCHAR, NgayGioChoi, 20)) N'Lịch Sử Người Chơi' FROM LichSuNguoiChoi " + " INNER JOIN TaiKhoanNguoiDung ON TaiKhoanNguoiDung.IDNguoiChoi = LichSuNguoiChoi.IDNguoiChoi ORDER BY NgayGioChoi DESC";
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
        private void Admin_TienThuong_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            num_1.Text = Convert.ToString(LaySoTaiKhoanDaTao());
            num_2.Text = Convert.ToString(LaySoTaiKhoanDaThamGiaChoi());
            num_3.Text = Convert.ToString(LaySoTaiKhoanChuaCapNhatThongTin());
            hienThi();
            hienThiNguoiChoi();
        }

        private void btnNguoiChoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new Admin_NguoiChoi();
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtSoCau.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtTienThuong.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String query = "UPDATE TienThuong SET Tien = @tien WHERE Cau = @cau";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@tien", SqlDbType.Int);
            sqlcmd.Parameters["@tien"].Value = int.Parse(txtTienThuong.Text);
            sqlcmd.Parameters.Add("@cau", SqlDbType.Int);
            sqlcmd.Parameters["@cau"].Value = int.Parse(txtSoCau.Text);
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Sửa Thành Công");
                hienThi();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtSoCau.Text = "";
            txtTienThuong.Text = "";
        }
    }
}
