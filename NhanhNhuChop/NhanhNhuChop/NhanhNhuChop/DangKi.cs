using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace NhanhNhuChop
{
    public partial class DangKi : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private String tendn;
        private String id;
        private int i;
        Match matches;
        public DangKi()
        {
            InitializeComponent();
        }
        private bool kiemTraUser(String s)
        {
            String regexName = "^[a-zA-Z0-9]*$";
            Regex regex = new Regex(regexName);
            matches = regex.Match(s);
            return matches.Success;
        }
        private int demDong()
        {
            sqlcmd = new SqlCommand();
            String query = "SELECT COUNT(*) FROM TaiKhoanNguoiDung";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            try
            {
                connect.conn.Open();
                i = (int)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return i;
        }
        private void themIDSangKetQua()
        {
            demDong();
            sqlcmd = new SqlCommand();
            String query = "INSERT INTO KetQua(IDNguoiChoi,Tien,SoCauCaoNhat,SoCauDung)VALUES (@id ,0,0,0)";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            id = "NNC000" + Convert.ToString(i);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nhap lai");
                ex.ToString();
            }
            connect.conn.Close();
        }
        private void themIDVaoThongTinCaNhan()
        {
            demDong();
            sqlcmd = new SqlCommand();
            String query = "INSERT INTO ThongTinCaNhan(IDNguoiChoi)VALUES (@id)";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            this.id = "NNC000" + Convert.ToString(i);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nhap lai");
                ex.ToString();
            }
            connect.conn.Close();
        }
        private String kiemTraTonTai()
        {
            String query = "SELECT TenDangNhap FROM TaiKhoanNguoiDung WHERE TenDangNhap = @tenDangNhap";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar);
            sqlcmd.Parameters["@tenDangNhap"].Value = txtTenDangNhap.Text;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                tendn = (String)sqlcmd.ExecuteScalar();
            }
            catch (SqlException ex) {
                MessageBox.Show("Lỗi ");
                ex.ToString();
            }
            connect.conn.Close();
            return tendn;
        }
        private void dangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dangNhap = new DangNhap();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            demDong();
            kiemTraTonTai();
            if (txtTenDangNhap.Text.Equals("") && txtMatKhau.Text.Equals("") && txtNhapLaiMatKhau.Text.Equals(""))
            {
                loiTenDangNhap.Text = "Tên đăng nhập được trống";
                loiMatKhau.Text = "Mật khẩu không được trống";
                loiMatKhau2.Text = "Mật khẩu không được trống";
            }
            else if (kiemTraUser(txtTenDangNhap.Text) == false)
            {
                loiTenDangNhap.Text = "Tên đăng nhập không đúng định dạng";
            }
            else if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                loiMatKhau.Text = "";
                loiMatKhau2.Text = "Mật khẩu phải giống";
            }
            else if (txtTenDangNhap.Text == tendn)
            {
                loiTenDangNhap.Text = "Tên đăng nhập đã tồn tại";
            }
            else if (txtTenDangNhap.Text == txtMatKhau.Text)
            {
                loiMatKhau.Text = "Tên đăng nhập mật khẩu không được giống";
            }
            else if (checkDongY.Checked == false)
            {

                loiMatKhau2.Text = "Vui lòng tick vào ô dưới";
            }
            else
            {
                sqlcmd = new SqlCommand();
                String query = "INSERT INTO TaiKhoanNguoiDung(IDNguoiChoi,TenDangNhap,MatKhau)VALUES (@id,@tenDangNhap,@matKhau)";
                sqlcmd.Connection = connect.conn;
                sqlcmd.CommandText = query;
                sqlcmd.Parameters.Add("@id", SqlDbType.Char);
                this.id = "NNC000" + Convert.ToString(i + 1);
                sqlcmd.Parameters["@id"].Value = id;
                sqlcmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar);
                sqlcmd.Parameters["@tenDangNhap"].Value = txtTenDangNhap.Text;
                sqlcmd.Parameters.Add("@matKhau", SqlDbType.VarChar);
                sqlcmd.Parameters["@matKhau"].Value = txtMatKhau.Text;
                try
                {
                    connect.conn.Open();
                    sqlcmd.ExecuteNonQuery();
                    connect.conn.Close();
                    themIDVaoThongTinCaNhan();
                    themIDSangKetQua();
                    connect.conn.Open();
                    MessageBox.Show("Thành Công");
                    this.Hide();
                    var dangNhap = new DangNhap(txtTenDangNhap.Text, "", this.id);
                    dangNhap.Closed += (s, args) => this.Close();
                    dangNhap.Show();
                }
                catch (SqlException ex)
                {
                    loiMatKhau2.Text = "Tên Đăng Nhập Đã Tồn Tại";
                    ex.ToString();
                }

            }
            connect.conn.Close();
        }
        private void DangKi_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraUser(txtTenDangNhap.Text))
            {
                loiTenDangNhap.Text = "";
            }
            else
            {
                loiTenDangNhap.Text = "Tên đăng nhập không đúng định dạng";
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraUser(txtMatKhau.Text))
            {
                loiMatKhau.Text = "";
            }
            else
            {
                loiMatKhau.Text = "Mật khẩu không đúng định dạng";
            }
        }

        private void txtNhapLaiMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == txtNhapLaiMatKhau.Text)
            {
                loiMatKhau2.Text = "";
            }
            else
            {
                loiMatKhau2.Text = "Mật khẩu phải giống";
            }
        }
    }
}
