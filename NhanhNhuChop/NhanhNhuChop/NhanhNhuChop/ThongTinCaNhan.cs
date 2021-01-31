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
    public partial class ThongTinCaNhan : Form
    {
        private String id;
        private String ten;
        private SqlCommand sqlcmd;
        private NguoiDung nd;
        private String pass;
        private MyConnect connect;
        public ThongTinCaNhan()
        {
            InitializeComponent();
        }
        
        public ThongTinCaNhan(String id,String ten)
        {
            InitializeComponent();
            this.id = id;
            this.ten = ten;
        }
        private String layMatKhauCu()
        {
            sqlcmd = new SqlCommand();
            String query = "SELECT MatKhau FROM TaiKhoanNguoiDung WHERE IDNguoiChoi = @id";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar);
            sqlcmd.Parameters["@id"].Value = this.id;

            try
            {
                connect.conn.Open();
                pass = (String)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return pass;
        }
        private void UpdateThongTin()
        {
            sqlcmd = new SqlCommand();
            String query = "UPDATE ThongTinCaNhan SET Ho = @ho , Ten = @ten ,GioiTinh = @gioiTinh ,NgaySinh = @ngaysinh, DiaChi = @diaChi ,Email =                               @email ,SoDienThoai = @soDienThoai WHERE IDNguoiChoi = @id ";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@ho", SqlDbType.NVarChar);
            sqlcmd.Parameters["@ho"].Value = txtHo.Text;
            sqlcmd.Parameters.Add("@ten", SqlDbType.NVarChar);
            sqlcmd.Parameters["@ten"].Value = txtTen.Text;
            sqlcmd.Parameters.Add("@gioiTinh", SqlDbType.NVarChar);
            sqlcmd.Parameters["@gioiTinh"].Value = gioiTinh1.Text;
            sqlcmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime);
            sqlcmd.Parameters["@ngaysinh"].Value = ngaySinh.Value;
            sqlcmd.Parameters.Add("@diaChi", SqlDbType.NVarChar);
            sqlcmd.Parameters["@diaChi"].Value = txtDiaChi.Text;
            sqlcmd.Parameters.Add("@email", SqlDbType.VarChar);
            sqlcmd.Parameters["@email"].Value = txtEmail.Text;
            sqlcmd.Parameters.Add("@soDienThoai", SqlDbType.Char);
            sqlcmd.Parameters["@soDienThoai"].Value = txtSoDienThoai.Text;
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();   
            }
            catch (SqlException e)
            {
                MessageBox.Show("Thất bại vui lòng thử lại");
                e.ToString();
            }
            connect.conn.Close();
        }
        private NguoiDung layThongTinNguoiDung()
        {
            String query = "SELECT TaiKhoanNguoiDung.TenDangNhap , Ho, Ten , GioiTinh , NgaySinh , DiaChi , Email , SoDienThoai FROM ThongTinCaNhan " +
            " INNER JOIN TaiKhoanNguoiDung ON ThongTinCaNhan.IDNguoiChoi = TaiKhoanNguoiDung.IDNguoiChoi " +
            " WHERE TaiKhoanNguoiDung.IDNguoiChoi = @id ";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                SqlDataReader reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                    txtTenDangNhapS.Text = reader[0].ToString();
                    nd.Ho = reader[1].ToString();
                    nd.Ten = reader[2].ToString();
                    nd.gioiTinh = reader[3].ToString();
                    ngaySinh.Value = Convert.ToDateTime(reader[4]);
                    nd.diaChi = reader[5].ToString();
                    nd.Email = reader[6].ToString();
                    nd.soDienThoai = reader[7].ToString();
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return nd;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            UpdateThongTin();
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            gioiTinh1.Enabled = false;
            ngaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            txtTenDangNhapS.Enabled = false;
            btnLuu.Visible = false;
            btnCapNhat.Visible = true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trangChu = new TrangChu(this.ten, this.id);
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            layMatKhauCu();
            if (txtMatKhauCu.Text.Equals("") && txtMatKhauMoi.Text.Equals("") && txtMatKhauMoiLai.Text.Equals(""))
            {
                loiDoiMatKhau.Text = "Mật khẩu không được trống";
            }
            else if (txtMatKhauCu.Text != pass)
            {
                loiDoiMatKhau.Text = "Nhập lại mật khẩu cũ";
            }
            else if (txtMatKhauMoi.Text != txtMatKhauMoiLai.Text)
            {
                loiDoiMatKhau.Text = "Mật khẩu phải giống";
            }
            else if (txtMatKhauMoi.Text.Equals("") && txtMatKhauMoiLai.Text.Equals(""))
            {
                loiDoiMatKhau.Text = "Nhập mật khẩu mới";
            }
            else if (txtMatKhauCu.Text.Equals(""))
            {
                loiDoiMatKhau.Text = "Nhập mật khẩu cũ";
            }
            else if (txtMatKhauMoi.Text.Equals(""))
            {
                loiDoiMatKhau.Text = "Mật khẩu không được trống";
            }
            else if (txtMatKhauMoiLai.Text.Equals(""))
            {
                loiDoiMatKhau.Text = "Mật khẩu không được trống";
            }
            else if (txtMatKhauCu.Text == txtMatKhauMoi.Text)
            {
                loiDoiMatKhau.Text = "Mật khẩu cũ và mới không được giống";
            }
            else
            {
                sqlcmd = new SqlCommand();
                String query = "UPDATE TaiKhoanNguoiDung SET MatKhau = @matKhau WHERE IDNguoiChoi  = @idNguoiChoi";
                sqlcmd.Connection = connect.conn;
                sqlcmd.CommandText = query;
                sqlcmd.Parameters.Add("@matKhau", SqlDbType.VarChar);
                sqlcmd.Parameters["@matKhau"].Value = txtMatKhauMoi.Text;
                sqlcmd.Parameters.Add("@idNguoiChoi", SqlDbType.VarChar);
                sqlcmd.Parameters["@idNguoiChoi"].Value = this.id;
                try
                {
                    connect.conn.Open();
                    sqlcmd.ExecuteNonQuery();
                    connect.conn.Close();
                    connect.conn.Open();
                    MessageBox.Show("Thanh Cong");
                    this.Hide();
                    var dangNhap = new DangNhap(this.id);
                    dangNhap.Closed += (s, args) => this.Close();
                    dangNhap.Show();
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Thất bại");
                    ex.ToString();
                }
            }
            connect.conn.Close();   
        }
        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            nd = new NguoiDung();
            layThongTinNguoiDung();
            txtHo.Text = nd.Ho;
            txtTen.Text = nd.Ten;
            gioiTinh1.Text = nd.gioiTinh;
            txtSoDienThoai.Text = nd.soDienThoai;
            txtEmail.Text = nd.Email;
            txtDiaChi.Text = nd.diaChi;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            btnCapNhat.Visible = false;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            gioiTinh1.Enabled = true;
            ngaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtEmail.Enabled = true;
        }
    }
}
