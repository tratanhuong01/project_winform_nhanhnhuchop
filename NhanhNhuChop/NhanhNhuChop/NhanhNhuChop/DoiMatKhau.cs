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
    public partial class DoiMatKhau : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private String email;
        private String tenDangNhap;
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
        }
        private String layTenDangNhap()
        {
            String query = "SELECT TenDangNhap FROM TaiKhoanNguoiDung WHERE TenDangNhap = @tendangnhap";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@tendangnhap", SqlDbType.Char);
            sqlcmd.Parameters["@tendangnhap"].Value = txtNhapLaiTenDangNhap.Text;
            try
            {
                connect.conn.Open();
                this.tenDangNhap = (String)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return this.tenDangNhap;
        }
        private String layEmail()
        {
            layTenDangNhap();
            String query = "SELECT Email FROM TaiKhoanNguoiDung INNER JOIN ThongTinCaNhan ON TaiKhoanNguoiDung.IDNguoiChoi = ThongTinCaNhan.IDNguoiChoi WHERE                    TaiKhoanNguoiDung.TenDangNhap = @tenDangNhap ";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar);
            sqlcmd.Parameters["@tenDangNhap"].Value = tenDangNhap;
            try
            {
                connect.conn.Open();
                this.email = (String)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return this.email;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (email == null)
            {
                loiTenDangNhap.Text = "Tên đăng nhập không đúng";
                emailNhapLai.Text = "";
            }
            layTenDangNhap();
            layEmail();
            if (txtNhapLaiTenDangNhap.Text == tenDangNhap)
            {
                loiTenDangNhap.Text = "";
                String chuoiCon = email.Substring(8);
                String emailMaHoa = "********" + chuoiCon;
                emailNhapLai.Text = emailMaHoa;
            }
            else
            {
                emailNhapLai.Text = "";
            }
        }
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            layEmail();
            if (txtEmailType.Text == email)
            {
                panel1.Enabled = true;
                loiEmail.Text = "";
            }
            else
            {
                loiEmail.Text = "Email không đúng";
                panel1.Enabled = false;
            }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text == "" && txtMatKhauMoiLai.Text == "")
            {
                loiMatKhauMoi.Text = "Mật khẩu không được trống";
                loiNhapLaiMatKhauMoi.Text = "Mật khẩu không được trống";
            }
            else if (txtMatKhauMoi.Text != txtMatKhauMoiLai.Text)
            {
                loiMatKhauMoi.Text = "";
                loiNhapLaiMatKhauMoi.Text = "Mật khẩu phải giống";
            }
            else
            {
                layTenDangNhap();
                String query = "UPDATE TaiKhoanNguoiDung SET MatKhau = @matKhau WHERE TenDangNhap = @tenDangNhap";
                sqlcmd = new SqlCommand(query, connect.conn);
                sqlcmd.Parameters.Add("@matKhau", SqlDbType.VarChar);
                sqlcmd.Parameters["@matKhau"].Value = txtMatKhauMoi.Text;
                sqlcmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar);
                sqlcmd.Parameters["@tenDangNhap"].Value = tenDangNhap;
                try
                {
                    connect.conn.Open();
                    sqlcmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Thất bại");
                    ex.ToString();
                }
                connect.conn.Close();
                panel1.Enabled = false;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dangNhap = new DangNhap();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }
    }
}
