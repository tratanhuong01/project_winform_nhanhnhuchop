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
    public partial class CapNhatThongTin : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private String id;
        private Match matches;
        public CapNhatThongTin()
        {
            InitializeComponent();
        }
        public CapNhatThongTin(String id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void LuuDuLieu()
        {
            String query = "SET DATEFORMAT dmy UPDATE ThongTinCaNhan SET Ho = @ho , Ten = @ten ,GioiTinh = @gioiTinh , NgaySinh = @ngaySinh," + 
            " DiaChi = @diaChi , Email = @email , SoDienThoai = @soDienThoai FROM ThongTinCaNhan WHERE IDNguoiChoi = @id ";
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            sqlcmd.Parameters.Add("@ho", SqlDbType.NVarChar);
            sqlcmd.Parameters["@ho"].Value = txtHo.Text;
            sqlcmd.Parameters.Add("@ten", SqlDbType.NVarChar);
            sqlcmd.Parameters["@ten"].Value = txtTen.Text;
            sqlcmd.Parameters.Add("@gioiTinh", SqlDbType.NVarChar);
            sqlcmd.Parameters["@gioiTinh"].Value = gioiTinh.Text;
            sqlcmd.Parameters.Add("@ngaySinh", SqlDbType.VarChar);
            sqlcmd.Parameters["@ngaySinh"].Value = ngaySinh.Value;
            sqlcmd.Parameters.Add("@diaChi", SqlDbType.NVarChar);
            sqlcmd.Parameters["@diaChi"].Value = txtDiaChi.Text;
            sqlcmd.Parameters.Add("@email", SqlDbType.VarChar);
            sqlcmd.Parameters["@email"].Value = txtEmail.Text;
            sqlcmd.Parameters.Add("@soDienThoai", SqlDbType.Char);
            sqlcmd.Parameters["@soDienThoai"].Value = txtSoDienThoai.Text;
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                this.Hide();
                var trangChu = new TrangChu(txtTen.Text, this.id);
                trangChu.Closed += (s, args) => this.Close();
                trangChu.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi");
                ex.ToString();
            }
            connect.conn.Close();
        }
        private bool kiemTraEmail(String s)
        {

            String regexName = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
        + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            Regex regex = new Regex(regexName);
            matches = regex.Match(s);
            return matches.Success;
        }
        private bool kiemTraHoTen(String s)
        {

            String regexName = "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
            "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
            "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";

            Regex regex = new Regex(regexName);
            matches = regex.Match(s);
            return matches.Success;
        }
        private bool kiemTraSoDienThoai(String s)
        {
            String regexName = @"^\+?(?:0|84)(?:\d){9}$";
            Regex regex = new Regex(regexName);
            matches = regex.Match(s);
            return matches.Success;
        }
        private bool kiemTraDiaChi(String s)
        {
            String regexName = "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
            "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
            "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";
            Regex regex = new Regex(regexName);
            matches = regex.Match(s);
            return matches.Success;
        }
        private void saveThongTin_Click(object sender, EventArgs e)
        {
            if (txtHo.Text == "" && txtTen.Text == "" && txtDiaChi.Text == "" && txtEmail.Text == "" && txtSoDienThoai.Text == "")
            {
                loiHo.Text = "Họ không để trống";
                loiTen.Text = "Tên không để trống";
                loiEmail.Text = "Email không để trống";
                loiSoDienThoai.Text = "Số Điện thoại không để trống";
                loiDiaChi.Text = "Địa Chỉ không để trống";
            }
            else
            {
                LuuDuLieu();
            } 

        }

        private void txtHo_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraHoTen(txtHo.Text))
            {
                loiHo.Text = "";
            }
            else
            {
                loiHo.Text = "Họ không đúng định dạng";
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraHoTen(txtTen.Text))
            {
                loiTen.Text = "";
            }
            else
            {
                loiTen.Text = "Tên không đúng định dạng";
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraDiaChi(txtDiaChi.Text))
            {
                loiDiaChi.Text = "";
            }
            else
            {
                loiDiaChi.Text = "Địa chỉ không đúng định dạng";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraEmail(txtEmail.Text))
            {
                loiEmail.Text = "";
            }
            else
            {
                loiEmail.Text = "Email không đúng định dạng";
            }
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraSoDienThoai(txtSoDienThoai.Text))
            {
                loiSoDienThoai.Text = "";
            }
            else
            {
                loiSoDienThoai.Text = "Số Điện Thoại không đúng định dạng";
            }
        }

        private void CapNhatThongTin_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
        }
    }
}
