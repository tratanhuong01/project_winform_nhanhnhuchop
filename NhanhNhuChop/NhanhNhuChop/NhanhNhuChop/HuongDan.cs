using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace NhanhNhuChop
{
    public partial class HuongDan : Form
    {
        SoundPlayer sound = new SoundPlayer(@Application.StartupPath + @"\Data\Music\HuongDan.wav");
        private int dem = 0;
        private String id;
        private String ten;
        public HuongDan()
        {
            InitializeComponent();
        }
        public HuongDan(String ten,String id)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
        }
        private void HuongDan_Load(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 50;
            timer1.Enabled = true;
            sound.Play();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                dem++;
                String chuoi = richTextBox1.Text;
                String[] s2 = chuoi.Split(' ');
                String s3 = "";
                if (dem >= chuoi.Length)
                {
                    timer1.Stop();
                }
                else
                {
                    s3 += s2[dem - 1] + " ";
                    label1.Text += s3;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            sound.Stop();
            this.Hide();
            var trangChu = new TrangChu(this.ten, this.id);
            trangChu.Closed += (s, args) => this.Close();
            trangChu.Show();
        }
    }
}
