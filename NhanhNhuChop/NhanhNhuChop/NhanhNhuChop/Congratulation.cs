using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NhanhNhuChop
{
    public partial class Congratulation : Form
    {
        private String id;
        private int dem;
        private String ten;
        private int tien;
        public Congratulation()
        {
            InitializeComponent();
        }
        
        public Congratulation(String ten, String id,int dem,int tien)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
            this.dem = dem;
            this.tien = tien;
        }
        
        private void Congratulation_Load(object sender, EventArgs e)
        {
            ketQuaLienTiep.Text = Convert.ToString(this.dem);
            String s = String.Format("{0:#,##0}", this.tien);
            tongTienWin.Text = Convert.ToString(s +   "    VNĐ");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home = new TrangChu(this.ten, this.id);
            home.Closed += (s, args) => this.Close();
            home.Show();
        }


        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home = new TrangChu(this.ten, this.id);
            home.Closed += (s, args) => this.Close();
            home.Show();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home = new GiaoDienChoi(this.ten,this.id);
            home.Closed += (s, args) => this.Close();
            home.Show();
        }

    }
}
