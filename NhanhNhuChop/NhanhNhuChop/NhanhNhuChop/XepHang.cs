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
    public partial class XepHang : Form
    {
        private MyConnect connect;
        private SqlCommand sqlcmd;
        private String ten;
        private String id;
        public XepHang()
        {
            InitializeComponent();
        }
        public XepHang(String id , String ten)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
        }
        private void XepHang_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            String query = "SELECT TOP 10 ROW_NUMBER() OVER (ORDER By KetQua.SoCauDung DESC) N'Số Thứ Tự' ,TaiKhoanNguoiDung.TenDangNhap N'Tên Đăng Nhập' , KetQua.SoCauDung N'Số Câu Đúng' FROM TaiKhoanNguoiDung " + "INNER JOIN KetQua ON TaiKhoanNguoiDung.IDNguoiChoi = KetQua.IDNguoiChoi";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var xepHang = new TrangChu(this.id, this.ten);
            xepHang.Closed += (s, args) => this.Close();
            xepHang.Show();
        }

        private void btnCauDungNhieuNhat_Click(object sender, EventArgs e)
        {
            String query = "SELECT TOP 10 ROW_NUMBER() OVER (ORDER By KetQua.SoCauDung DESC) N'Số Thứ Tự' , TaiKhoanNguoiDung.TenDangNhap N'Tên Đăng Nhập ' , KetQua.SoCauDung N'Số Câu Đúng' FROM TaiKhoanNguoiDung " +
            "INNER JOIN KetQua ON TaiKhoanNguoiDung.IDNguoiChoi = KetQua.IDNguoiChoi";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
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

        private void btnTongTaiSan_Click(object sender, EventArgs e)
        {
            String query = "SELECT TOP 10 ROW_NUMBER() OVER (ORDER By KetQua.Tien DESC) N'Số Thứ Tự' , TaiKhoanNguoiDung.TenDangNhap N'Tên Đăng Nhập' ," +
            " KetQua.Tien N'Tiền' FROM TaiKhoanNguoiDung " + "INNER JOIN KetQua ON TaiKhoanNguoiDung.IDNguoiChoi = KetQua.IDNguoiChoi";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
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
    }
}
