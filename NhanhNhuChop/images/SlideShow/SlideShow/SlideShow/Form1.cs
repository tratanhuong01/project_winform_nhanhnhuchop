using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace SlideShow
{
    public partial class frmSlideShow : Form
    {
        string Dirpath;
        int imgindex;

        public frmSlideShow()
        {
            InitializeComponent();
        }

        private void frmSlideShow_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                comboBox1.Items.Add(i);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                listBox1.Items.Clear();
                Dirpath = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(Dirpath, "*.png");
                foreach (string file in files)
                {
                    int pos = file.LastIndexOf("||");
                    string FName = file.Substring(pos + 1);
                    listBox1.Items.Add(FName);
                }
                listBox1.SelectedIndex = imgindex = 0;
                btnPrev.Enabled = true;
                btnNext.Enabled = btnSlideShow.Enabled = true;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = listBox1.SelectedItem.ToString();
            // pictureBox1.ImageLocation = Dirpath + "\\" + listBox1.SelectedItem;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (imgindex > 0)
            {
                imgindex -= 1;
                if (imgindex == 0)
                {
                    btnPrev.Enabled = false;
                }
                if (imgindex < listBox1.Items.Count - 1)
                    btnNext.Enabled = true;
                listBox1.SelectedIndex = imgindex;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (imgindex < listBox1.Items.Count - 1)
            {
                imgindex += 1;
                if (imgindex == listBox1.Items.Count - 1)
                    btnNext.Enabled = false;
                if (imgindex > 0)
                    btnPrev.Enabled = true;
                listBox1.SelectedIndex = imgindex;
            }

        }

        private void btnSlideShow_Click(object sender, EventArgs e)
        {
            if (btnSlideShow.Text == "Slide Show")
            {
                btnSlideShow.Text = "Stop Show";
                timer1.Interval = int.Parse(comboBox1.Text) * 1000;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                btnSlideShow.Text = "Slide Show";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnNext.PerformClick();
        }
    }
}
