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
    public partial class Congratulation2 : Form
    {
        private String id;
        private String ten;
        private int dem;
        public Congratulation2()
        {
            InitializeComponent();
        }
        public Congratulation2(String ten, String id)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
        }
        public Congratulation2(String ten, String id,int dem)
        {
            InitializeComponent();
            this.ten = ten;
            this.id = id;
            this.dem = dem;
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
            var home = new GiaoDienChoi(this.ten, this.id);
            home.Closed += (s, args) => this.Close();
            home.Show();
        }

        private void Congratulation2_Load(object sender, EventArgs e)
        {

        }
    }
}
