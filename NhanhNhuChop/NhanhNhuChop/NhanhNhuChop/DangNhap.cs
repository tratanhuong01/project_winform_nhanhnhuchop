using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;

namespace NhanhNhuChop
{
    public partial class DangNhap : Form
    {
        private SqlCommand sqlcmd;
        private String id;
        private String kq;
        private String ten;
        private String tenDangNhap;
        private String matKhau;
        private MyConnect connect;
        public DangNhap()
        {
            InitializeComponent();
        }
        public DangNhap(String id)
        {
            InitializeComponent();
            this.id = id;
        }
        public DangNhap(String tenDangNhap, String matKhau)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }
        public DangNhap(String tenDangNhap, String matKhau, String id)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.id = id;
        }
        private String layIDNguoiChoi()
        {
            sqlcmd = new SqlCommand();
            String query = "SELECT IDNguoiChoi FROM TaiKhoanNguoiDung WHERE TenDangNhap = @tenDangNhap and MatKhau = @matKhau;";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar);
            sqlcmd.Parameters["@tenDangNhap"].Value = txtTenDangNhap.Text;
            sqlcmd.Parameters.Add("@matKhau", SqlDbType.VarChar);
            sqlcmd.Parameters["@matKhau"].Value = txtMatKhau.Text;
            try
            {
                connect.conn.Open();
                this.id = (String)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return this.id;
        }
        private String kiemTraTaiKhoanDaCoThongTinChua()
        {
            String query = "select IDNguoiChoi from ThongTinCaNhan where Ho is not null and Ten is not null and DiaChi is not null  and Email is not null and                     SoDienThoai is not null and IDNguoiChoi = @id ";
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                kq = (String)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("That Bai");
                ex.ToString();
            }
            connect.conn.Close();
            return kq;
        }
        
        private String layTen()
        {
            string query = "SELECT Ten FROM ThongTinCaNhan WHERE IDNguoiChoi = @id";
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                
                ten = (String)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Chua Lay Duoc Ten");
                ex.ToString();
            }
            connect.conn.Close();
            return ten;
        }
        private void btnDangNhap1_Click(object sender, EventArgs e)
        {
            string query = "SELECT IDNguoiChoi, TenDangNhap , MatKhau FROM " +
                "TaiKhoanNguoiDung WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau";
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;

            sqlcmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar);
            sqlcmd.Parameters["@tenDangNhap"].Value = txtTenDangNhap.Text;
            sqlcmd.Parameters.Add("@matKhau", SqlDbType.VarChar);
            sqlcmd.Parameters["@matKhau"].Value = txtMatKhau.Text;
            try
            {
                connect.conn.Open();
                //sqlcmd.ExecuteNonQuery();
                SqlDataReader readers = sqlcmd.ExecuteReader();
                
                if (readers.Read())
                {
                    connect.conn.Close();
                    layIDNguoiChoi();
                    kiemTraTaiKhoanDaCoThongTinChua();
                    
                    if (this.kq == this.id)
                    {
                        layTen();
                        this.Hide();
                        var trangChu = new TrangChu(this.ten, this.id);
                        trangChu.Closed += (s, args) => this.Close();
                        trangChu.Show();
                    }
                    else
                    {
                        this.Hide();
                        var capNhatThongTin = new CapNhatThongTin(this.id);
                        capNhatThongTin.Closed += (s, args) => this.Close();
                        capNhatThongTin.Show();
                    }
                }
                else if (txtTenDangNhap.Text.Equals("") && txtMatKhau.Text.Equals(""))
                {
                    errorPass.Text = "Tên đăng nhập hoặc mật khẩu không được để trống";
                }
                else if (txtTenDangNhap.Text.Equals("") && txtMatKhau.Text != "")
                {
                    errorPass.Text = "Tên đăng nhập không được để trống";
                }
                else if (txtTenDangNhap.Text != "" && txtMatKhau.Text.Equals(""))
                {
                    errorPass.Text = "Mật khẩu không được để trống";
                }
                else
                {
                    errorPass.ForeColor = Color.Red;
                    errorPass.Text = "Tên đăng nhập hoặc mật khẩu không đúng thử lại";
                }
                connect.conn.Close();   
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
                MessageBox.Show("Lỗi Kết Nối");
            }
            connect.conn.Close();     
        }
        private void quenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            var doiMatKhau = new DoiMatKhau();
            doiMatKhau.Closed += (s, args) => this.Close();
            doiMatKhau.Show();
        }
        private void taoTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dangKi = new DangKi();
            dangKi.Closed += (s, args) => this.Close();
            dangKi.Show();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            txtTenDangNhap.Text = this.tenDangNhap;
            txtMatKhau.Text = this.matKhau;
        }
    }
}
