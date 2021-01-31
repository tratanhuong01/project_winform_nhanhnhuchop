using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Media;
namespace NhanhNhuChop
{
    public partial class GiaoDienChoi : Form
    {
        private MyConnect connect;
        SqlCommand sqlcmd;
        String dapan;
        private int soDong = 0;
        SoundPlayer sound = new SoundPlayer(@Application.StartupPath + @"\Data\Music\BatDauTroChoi.wav");
        SoundPlayer amthanh1 = new SoundPlayer(@Application.StartupPath + @"\Data\Music\AmThanhSanSang.wav");
        SoundPlayer amthanh2 = new SoundPlayer(@Application.StartupPath + @"\Data\Music\AmThanhDung.wav");
        SoundPlayer amthanh3 = new SoundPlayer(@Application.StartupPath + @"\Data\Music\AmThanSai1.wav");
        private int tien = 0;
        private int count = 0;
        private int giay1 = 5;
        private int giay = 60;
        private int dem;
        private String id;
        private String ten;
        private int getTien;
        private int getSoCau;
        private int demCauDung = 0;
        private int demCauSai = 0;
        private DateTime ngay;
        private int demCauHoi;
        private int countCauHoi = 0;
        private Button[] btn;
        private PictureBox[] pic;
        private int[] tienThuong;
        public GiaoDienChoi()
        {
            InitializeComponent();
        }
        public GiaoDienChoi(String id)
        {
            InitializeComponent();
            this.id = id;
        }
        public GiaoDienChoi(String ten,String id)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
        }
        public GiaoDienChoi(String ten, String id, int count)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
            this.count = count;
        }
        private int demDong()
        {
            sqlcmd = new SqlCommand();
            String query = "SELECT COUNT(*) FROM LichSuNguoiChoi";
            sqlcmd.Connection = connect.conn;
            sqlcmd.CommandText = query;
            try
            {
                connect.conn.Open();
                soDong = (int)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return soDong;
        }
        private Button[] danhSachButton()
        {
            Button btn0 = new Button();
            btn = new Button[] {btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10 };
            return btn;
        }
        private PictureBox[] danhSachPictureBox()
        {
            PictureBox pic0 = new PictureBox();
            pic = new PictureBox[] {pic0, pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10 };
            return pic;
        }
        private int[] danhSachTienThuong()
        {
            tienThuong = new int[11];
            String query = "SELECT Tien FROM TienThuong";
            sqlcmd = new SqlCommand(query, connect.conn);
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                SqlDataReader reader = sqlcmd.ExecuteReader();
                int dong = 0;
                while (reader.Read())
                {
                    tienThuong[dong] = int.Parse(reader[0].ToString());
                    dong++;
                }
            }
            catch (SqlException e)
            {
                e.ToString();
            }
            connect.conn.Close();
            return tienThuong;
        }
        private String taoIDLichSu()
        {
            demDong();
            return "LSNCNNC0" + Convert.ToString(soDong + 1);
        }
        private void hienThiDuLieuLenDataGridView(int x)
        {
            String query = "SELECT * FROM DanhSachCauHoi WHERE DoKho = @dokho";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@dokho", SqlDbType.Int);
            sqlcmd.Parameters["@dokho"].Value = x;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlapdap = new SqlDataAdapter(sqlcmd);
                DataTable data = new DataTable();
                sqlapdap.Fill(data);
                connect.conn.Close();
                dataGridView1.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Thất Bại");
                ex.ToString();
            }
            connect.conn.Close();
        }
        private int demCauHoiTheoDoKho(int x)
        {
            String query = "SELECT COUNT(*) FROM DanhSachCauHoi WHERE DoKho = @doKho";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@doKho", SqlDbType.Int);
            sqlcmd.Parameters["@doKho"].Value = x;
            try
            {
                connect.conn.Open();
                countCauHoi = (int)sqlcmd.ExecuteScalar();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            connect.conn.Close();
            return countCauHoi;
        }
        private CauHoi questions()
        {
            CauHoi cauHoi = new CauHoi();
            try
            {
                connect.conn.Close();
                hienThiDuLieuLenDataGridView(count);
                demCauHoiTheoDoKho(count);
                Random rand = new Random();
                int x = rand.Next(0,countCauHoi);
                if (x < countCauHoi)
                {
                    cauHoi.cauHoi1 = dataGridView1.Rows[x].Cells[1].Value.ToString();
                    cauHoi.dapAn_A = dataGridView1.Rows[x].Cells[2].Value.ToString();
                    cauHoi.dapAn_B = dataGridView1.Rows[x].Cells[3].Value.ToString();
                    cauHoi.dapAn_C = dataGridView1.Rows[x].Cells[4].Value.ToString();
                    cauHoi.dapAn_D = dataGridView1.Rows[x].Cells[5].Value.ToString();
                    cauHoi.dapAn = dataGridView1.Rows[x].Cells[6].Value.ToString();
                }   
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Thất Bại");
                ex.ToString();
            }
            return cauHoi;
        }
        private void hienThiCauHoi()
        {
            CauHoi ch = new CauHoi();
            ch = questions();
            IDCauHoi.Text = ch.idcauhoi;
            txtCauHoi.Text = ch.cauHoi1;
            btnDapAn_A.Text = ch.dapAn_A;
            btnDapAn_B.Text = ch.dapAn_B;
            btnDapAn_C.Text = ch.dapAn_C;
            btnDapAn_D.Text = ch.dapAn_D;
            this.dapan = ch.dapAn;
        }
        private void layKetQua()
        {
            String query = "SELECT Tien , SoCauDung FROM KetQua WHERE IDNguoiChoi = @id ";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
                SqlDataReader reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                    this.getTien = int.Parse(reader[0].ToString());
                    this.getSoCau = int.Parse(reader[1].ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("thất bại");
                ex.ToString();
            }
            connect.conn.Close();
        }
        private void sanSang_Click(object sender, EventArgs e)
        {
            this.ngay = DateTime.Now;
            amthanh1.Play();
            demGiayBatDau = new Timer();
            demGiayBatDau.Tick += demGiayBatDau_Tick;
            demGiayBatDau.Interval = 1000;
            demGiayBatDau.Enabled = !demGiayBatDau.Enabled;
            demGiayBatDau.Start();
            sanSang.Visible = false;
            hienThiCauHoi();
        }
        private void btnDapAn_A_Click(object sender, EventArgs e)
        {
            btnTiepTuc.Visible = true;
            btnDapAn_B.Enabled = false;
            btnDapAn_D.Enabled = false;
            btnDapAn_C.Enabled = false;
            demCauHoi++;
            if (btnDapAn_A.Text == this.dapan)
            {
                demCauDung++;
                amthanh2.Play();
                count++;
                btnDapAn_A.BackColor = Color.Yellow;
            }
            else
            {
                demCauSai++;;
                count = 0;
                btnDapAn_A.BackColor = Color.Red;
                amthanh3.Play();
            }
        }
        private void btnDapAn_B_Click(object sender, EventArgs e)
        {
            btnTiepTuc.Visible = true;
            btnDapAn_A.Enabled = false;
            btnDapAn_D.Enabled = false;
            btnDapAn_C.Enabled = false;
            demCauHoi++;
            if (btnDapAn_B.Text == this.dapan) 
            {
                demCauDung++;
                amthanh2.Play();
                count++;
                btnDapAn_B.BackColor = Color.Yellow;
            }
            else 
            {
                demCauSai++;
                amthanh3.Play();
                count = 0;
                btnDapAn_B.BackColor = Color.Red;
            }
        }
        private void btnDapAn_C_Click(object sender, EventArgs e)
        {
            demCauHoi++;
            btnTiepTuc.Visible = true;
            btnDapAn_A.Enabled = false;
            btnDapAn_B.Enabled = false;
            btnDapAn_D.Enabled = false;
            sound.Play();
            if (btnDapAn_C.Text == this.dapan)
            {
                demCauDung++;
                amthanh2.Play();
                count++;
                btnDapAn_C.BackColor = Color.Yellow; 
            }
            else
            {
                demCauSai++;
                amthanh3.Play();
                count = 0;
                btnDapAn_C.BackColor = Color.Red; 
            }
        }
        private void btnDapAn_D_Click(object sender, EventArgs e)
        {
            demCauHoi++;
            btnTiepTuc.Visible = true;
            sound.Play();
            if (btnDapAn_D.Text == this.dapan)
            {
                demCauDung++;
                amthanh2.Play();
                btnDapAn_D.BackColor = Color.Yellow;
                count++;
            }
            else
            {
                demCauSai++;
                amthanh3.Play();
                count = 0;
                btnDapAn_D.BackColor = Color.Red;
            }
            btnDapAn_A.Enabled = false;
            btnDapAn_B.Enabled = false;
            btnDapAn_C.Enabled = false;
        }
        private void XuLiKetQua(int i)
        {
            tien += tienThuong[i];
            tienWin.Text = Convert.ToString(string.Format("{0:#,##0}", tien)) + " VNĐ";
            if (i <= 0)
            {
                i = 0;
                tien = 0;
            }
            else if (i == 10)
            {
                demGiayChoi.Stop();
                themLichSuVaoDatabase();
                layKetQua();
                getTien += tien;
                getSoCau += count;
                capNhatKetQua();
                this.Hide();
                var loginForm = new Congratulation2(this.ten, this.id, this.count);
                loginForm.Closed += (s, args) => this.Close();
                loginForm.Show();
            }
            else if (i >= 1 && i < 10)
            {
                pic[i].Visible = true;
                pic[i - 1].Visible = false;
                btn[i].BackColor = Color.Yellow;
            }
            else 
            {
                for (int j = 0; j < 10; j++)
                {
                    pic[j].Visible = false;
                    btn[j].BackColor = Color.SandyBrown;
                }
            }
        }
        private void themLichSuVaoDatabase()
        {
            try
            {
                String idL = taoIDLichSu();
                dem = demCauDung + demCauSai;
                sqlcmd = new SqlCommand();
                String query = "INSERT INTO LichSuNguoiChoi                                                             (IDNguoiChoi,IDLichSu,SoCauLienTiep,TongSoCau,SoCauDung,SoCauSai,NgayGioChoi,TienThang,SoGiay)VALUES                         (@idNguoiChoi,@idLichSu,@soCauLienTiep,@tongCau,@soCauDung,@soCauSai,@ngay,@tienThang,@soGiay)";

                sqlcmd.Connection = connect.conn;
                sqlcmd.CommandText = query;
                sqlcmd.Parameters.Add("@idNguoiChoi", SqlDbType.Char);
                sqlcmd.Parameters["@idNguoiChoi"].Value = this.id;
                sqlcmd.Parameters.Add("@idLichSu", SqlDbType.Char);
                sqlcmd.Parameters["@idLichSu"].Value = idL;
                sqlcmd.Parameters.Add("@soCauLienTiep", SqlDbType.Int);
                sqlcmd.Parameters["@soCauLienTiep"].Value = this.count;
                sqlcmd.Parameters.Add("@tongCau", SqlDbType.Int);
                sqlcmd.Parameters["@tongCau"].Value = dem;
                sqlcmd.Parameters.Add("@soCauDung", SqlDbType.Int);
                sqlcmd.Parameters["@soCauDung"].Value = demCauDung;
                sqlcmd.Parameters.Add("@soCauSai", SqlDbType.Int);
                sqlcmd.Parameters["@soCauSai"].Value = demCauSai;
                sqlcmd.Parameters.Add("@ngay", SqlDbType.DateTime);
                sqlcmd.Parameters["@ngay"].Value = this.ngay;
                sqlcmd.Parameters.Add("@tienThang", SqlDbType.Int);
                sqlcmd.Parameters["@tienThang"].Value = tien;
                sqlcmd.Parameters.Add("@soGiay", SqlDbType.Int);
                sqlcmd.Parameters["@soGiay"].Value = 60 - giay;
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
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            btnTiepTuc.Visible = false;
            btnDapAn_A.Enabled = true;
            btnDapAn_B.Enabled = true;
            btnDapAn_D.Enabled = true;
            btnDapAn_C.Enabled = true;
            XuLiKetQua(count);
            btnDapAn_A.BackColor = Color.White;
            btnDapAn_B.BackColor = Color.White;
            btnDapAn_C.BackColor = Color.White;
            btnDapAn_D.BackColor = Color.White;
            hienThiCauHoi();
        }
        private void capNhatKetQua()
        {
            String query = "UPDATE KetQua SET Tien = @tien , SoCauCaoNhat = @soCaocaoNhat , SoCauDung = @soCauDung WHERE IDNguoiChoi = @id ";
            sqlcmd = new SqlCommand(query, connect.conn);
            sqlcmd.Parameters.Add("@tien", SqlDbType.Int);
            sqlcmd.Parameters["@tien"].Value = getTien;
            sqlcmd.Parameters.Add("@soCaocaoNhat", SqlDbType.Int);
            sqlcmd.Parameters["@soCaocaoNhat"].Value = count;
            sqlcmd.Parameters.Add("@soCauDung", SqlDbType.Int);
            sqlcmd.Parameters["@soCauDung"].Value = getSoCau;
            sqlcmd.Parameters.Add("@id", SqlDbType.Char);
            sqlcmd.Parameters["@id"].Value = this.id;
            try
            {
                connect.conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
        }
        private void GiaoDienChoi_Load(object sender, EventArgs e)
        {
            connect = new MyConnect();
            connect.Connect();
            this.count = 0;
            danhSachButton();
            danhSachPictureBox();
            danhSachTienThuong();
        }
        private void btnDungLai_Click(object sender, EventArgs e)
        {
            demGiayChoi.Stop();
            this.ngay = DateTime.Now;
            themLichSuVaoDatabase();
            layKetQua();
            getSoCau += count;
            getTien += tien;
            capNhatKetQua();
            this.Hide();
            var win1 = new TrangChu(this.ten, this.id);
            win1.Closed += (s, args) => this.Close();
            win1.Show();
        }

        private void demGiayBatDau_Tick(object sender, EventArgs e)
        {
            giay1--;
            if (giay1 == 0)
            {
                btnDapAn_A.Visible = true;
                btnDapAn_B.Visible = true;
                btnDapAn_C.Visible = true;
                btnDapAn_D.Visible = true;
                txtCauHoi.Visible = true;
                btnTiepTuc.Visible = false;
                amthanh1.Stop();
                sound.Play();
                demGiayChoi = new Timer();
                demGiayChoi.Interval = 1000;
                demGiayChoi.Tick += demGiayChoi_Tick;
                demGiayChoi.Enabled = true;
                demGiayChoi.Start();
            }
        }
        private void demGiayChoi_Tick(object sender, EventArgs e)
        {
            giay--;
            demGio.Text = giay.ToString();
            if (giay == 0)
            {
                demGiayChoi.Stop();
                themLichSuVaoDatabase();
                layKetQua();
                getTien += tien;
                getSoCau += count;
                capNhatKetQua();
                sound.Stop();
                this.Hide();
                var win1 = new Congratulation(this.ten, this.id, this.count, this.tien);
                win1.Closed += (s, args) => this.Close();
                win1.Show();
            }
            connect.conn.Close();
        }
    }
}