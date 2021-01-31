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
    public partial class Admin_CauHoi : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private int num1;
        private int num2;
        private int num3;
        public Admin_CauHoi()
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
            String query = "SELECT * FROM DanhSachCauHoi";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
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
        private void Admin_CauHoi_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            num_1.Text = Convert.ToString(LaySoTaiKhoanDaTao());
            num_2.Text = Convert.ToString(LaySoTaiKhoanDaThamGiaChoi());
            num_3.Text = Convert.ToString(LaySoTaiKhoanChuaCapNhatThongTin());
            connect.conn.Open();
            hienThi();
            connect.conn.Close();
            hienThiNguoiChoi();
        }
        private void btnNguoiChoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new Admin_NguoiChoi();
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtIDCauHoi.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtCauHoi.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtDapAn_A.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtDapAn_B.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtDapAn_C.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtDapAn_D.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtDapAn.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtDoKho.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "INSERT INTO DanhSachCauHoi(IDCauHoi,CauHoi,A,B,C,D,DapAn,DoKho)VALUES (@idCauHoi,@cauHoi,@a,@b,@c,@d,@dapAn,@doKho)";
                sqlcmd = new SqlCommand(query, connect.conn);
                sqlcmd.Parameters.Add("@idCauHoi", SqlDbType.VarChar);
                sqlcmd.Parameters["@idCauHoi"].Value = txtIDCauHoi.Text;
                sqlcmd.Parameters.Add("@cauHoi", SqlDbType.NVarChar);
                sqlcmd.Parameters["@cauHoi"].Value = txtCauHoi.Text;
                sqlcmd.Parameters.Add("@a", SqlDbType.NVarChar);
                sqlcmd.Parameters["@a"].Value = txtDapAn_A.Text;
                sqlcmd.Parameters.Add("@b", SqlDbType.NVarChar);
                sqlcmd.Parameters["@b"].Value = txtDapAn_B.Text;
                sqlcmd.Parameters.Add("@c", SqlDbType.NVarChar);
                sqlcmd.Parameters["@c"].Value = txtDapAn_C.Text;
                sqlcmd.Parameters.Add("@d", SqlDbType.NVarChar);
                sqlcmd.Parameters["@d"].Value = txtDapAn_D.Text;
                sqlcmd.Parameters.Add("@dapAn", SqlDbType.NVarChar);
                sqlcmd.Parameters["@dapAn"].Value = txtDapAn.Text;
                sqlcmd.Parameters.Add("@doKho", SqlDbType.Int);
                sqlcmd.Parameters["@doKho"].Value = int.Parse(txtDoKho.Text);
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Thành Công");
                hienThi();
            }
            catch (SqlException ex)
            {
                ex.ToString();
                MessageBox.Show("Trùng ID Câu Hỏi ");
                
            }
            connect.conn.Close();
            
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            String query = "UPDATE DanhSachCauHoi SET IDCauHoi = @idCauHoi , CauHoi = @cauHoi ,A = @a, B = @b ,C = @c,D = @d,DapAn =  @dapAn,DoKho = @doKho WHERE IDCauHoi = @idcauHoi";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@idCauHoi", SqlDbType.VarChar);
            sqlcmd.Parameters["@idCauHoi"].Value = txtIDCauHoi.Text;
            sqlcmd.Parameters.Add("@cauHoi", SqlDbType.NVarChar);
            sqlcmd.Parameters["@cauHoi"].Value = txtCauHoi.Text;
            sqlcmd.Parameters.Add("@a", SqlDbType.NVarChar);
            sqlcmd.Parameters["@a"].Value = txtDapAn_A.Text;
            sqlcmd.Parameters.Add("@b", SqlDbType.NVarChar);
            sqlcmd.Parameters["@b"].Value = txtDapAn_B.Text;
            sqlcmd.Parameters.Add("@c", SqlDbType.NVarChar);
            sqlcmd.Parameters["@c"].Value = txtDapAn_C.Text;
            sqlcmd.Parameters.Add("@d", SqlDbType.NVarChar);
            sqlcmd.Parameters["@d"].Value = txtDapAn_D.Text;
            sqlcmd.Parameters.Add("@dapAn", SqlDbType.NVarChar);
            sqlcmd.Parameters["@dapAn"].Value = txtDapAn.Text;
            sqlcmd.Parameters.Add("@doKho", SqlDbType.Int);
            sqlcmd.Parameters["@doKho"].Value = int.Parse(txtDoKho.Text);
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Sửa Thành Công ");
                hienThi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Trùng ID Câu Hỏi");
                ex.Errors.ToString();
            }
            connect.conn.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM DanhSachCauHoi WHERE IDCauHoi = @idCauHoi ";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@idCauHoi", SqlDbType.VarChar);
            sqlcmd.Parameters["@idCauHoi"].Value = txtIDCauHoi.Text;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Xóa Thành Công");
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
            txtIDCauHoi.Text = "";
            txtCauHoi.Text = "";
            txtDapAn_A.Text = "";
            txtDapAn_B.Text = "";
            txtDapAn_C.Text = "";
            txtDapAn_D.Text = "";
            txtDapAn.Text = "";
            txtDoKho.Text = "";
        }
        private void btnTienThuong_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new Admin_TienThuong();
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }
    }
}
