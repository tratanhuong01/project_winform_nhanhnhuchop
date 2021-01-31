using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;
namespace NhanhNhuChop
{
    public partial class TrangChu : Form
    {
        private MyConnect connect;
        SoundPlayer j;
        private String ten;
        private String id;
        private SqlCommand sqlcmd;
        private String tenDangNhap;
        private String matKhau;
        public TrangChu()
        {
            InitializeComponent();
        }
        public TrangChu(String lb)
        {
            InitializeComponent();
            this.ten = lb;
        }
        public TrangChu(String lb, String id)
        {
            InitializeComponent();
            this.ten = lb;
            this.id = id;
        }
        private void PlayMusic()
        {
            j = new SoundPlayer(@Application.StartupPath + @"\Data\Music\nhanhnhuchop.wav");
            j.Play();
        }
        private void layKetQua()
        {
            String query = "SELECT Tien , SoCauCaoNhat ,SoCauDung FROM KetQua WHERE IDNguoiChoi = @id ";
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
                    txtTongTaiSan.Text = String.Format("{0:#,##0}", int.Parse(reader[0].ToString())) + "   VNĐ";
                    txtSoCauCaoNhat.Text = Convert.ToString(reader[1].ToString()) + " Câu";
                    txtTongCauDung.Text = Convert.ToString(reader[2].ToString()) + "  Câu";
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
        }
        private void btnLichSu_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            var lichSuNguoiDung = new LichSuNguoiDung(this.ten, this.id);
            lichSuNguoiDung.Closed += (s, args) => this.Close();
            lichSuNguoiDung.Show();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            PlayMusic();
            hello.Text = this.ten;
            layKetQua();
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            var giaoDienChoi = new GiaoDienChoi(this.ten, this.id);
            giaoDienChoi.Closed += (s, args) => this.Close();
            giaoDienChoi.Show();
        }
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            var thongTinCaNhan = new ThongTinCaNhan(this.id,this.ten);
            thongTinCaNhan.Closed += (s, args) => this.Close();
            thongTinCaNhan.Show();
        }
        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            var huongDan = new HuongDan(this.ten, this.id);
            huongDan.Closed += (s, args) => this.Close();
            huongDan.Show();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            var dangNhap = new DangNhap(this.tenDangNhap, this.matKhau);
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            var xepHang = new XepHang(this.ten, this.id);
            xepHang.Closed += (s, args) => this.Close();
            xepHang.Show();
        }
    }
}
