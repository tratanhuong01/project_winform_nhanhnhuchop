namespace NhanhNhuChop
{
    partial class XepHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XepHang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhanhNhat = new System.Windows.Forms.Button();
            this.btnTongTaiSan = new System.Windows.Forms.Button();
            this.btnCauDungNhieuNhat = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::NhanhNhuChop.Properties.Resources.background;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1421, 794);
            this.panel1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::NhanhNhuChop.Properties.Resources.background;
            this.button6.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(12, 14);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(250, 80);
            this.button6.TabIndex = 4;
            this.button6.Text = "Về Trang Chủ";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::NhanhNhuChop.Properties.Resources.background;
            this.button5.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1140, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(250, 80);
            this.button5.TabIndex = 3;
            this.button5.Text = "Về Trang Chủ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(474, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(468, 80);
            this.button4.TabIndex = 2;
            this.button4.Text = "Bảng Xếp Hạng";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.btnNhanhNhat);
            this.panel2.Controls.Add(this.btnTongTaiSan);
            this.panel2.Controls.Add(this.btnCauDungNhieuNhat);
            this.panel2.Location = new System.Drawing.Point(12, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1395, 660);
            this.panel2.TabIndex = 0;
            // 
            // btnNhanhNhat
            // 
            this.btnNhanhNhat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNhanhNhat.BackgroundImage")));
            this.btnNhanhNhat.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanhNhat.Location = new System.Drawing.Point(929, 0);
            this.btnNhanhNhat.Name = "btnNhanhNhat";
            this.btnNhanhNhat.Size = new System.Drawing.Size(466, 80);
            this.btnNhanhNhat.TabIndex = 2;
            this.btnNhanhNhat.Text = "Nhanh Nhất";
            this.btnNhanhNhat.UseVisualStyleBackColor = true;
            // 
            // btnTongTaiSan
            // 
            this.btnTongTaiSan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTongTaiSan.BackgroundImage")));
            this.btnTongTaiSan.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongTaiSan.Location = new System.Drawing.Point(462, 0);
            this.btnTongTaiSan.Name = "btnTongTaiSan";
            this.btnTongTaiSan.Size = new System.Drawing.Size(468, 80);
            this.btnTongTaiSan.TabIndex = 1;
            this.btnTongTaiSan.Text = "Tổng Tài Sản";
            this.btnTongTaiSan.UseVisualStyleBackColor = true;
            this.btnTongTaiSan.Click += new System.EventHandler(this.btnTongTaiSan_Click);
            // 
            // btnCauDungNhieuNhat
            // 
            this.btnCauDungNhieuNhat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCauDungNhieuNhat.BackgroundImage")));
            this.btnCauDungNhieuNhat.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCauDungNhieuNhat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCauDungNhieuNhat.Location = new System.Drawing.Point(0, 0);
            this.btnCauDungNhieuNhat.Name = "btnCauDungNhieuNhat";
            this.btnCauDungNhieuNhat.Size = new System.Drawing.Size(468, 80);
            this.btnCauDungNhieuNhat.TabIndex = 0;
            this.btnCauDungNhieuNhat.Text = "Câu Đúng Nhiều Nhất";
            this.btnCauDungNhieuNhat.UseVisualStyleBackColor = true;
            this.btnCauDungNhieuNhat.Click += new System.EventHandler(this.btnCauDungNhieuNhat_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 30);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1389, 571);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.VirtualMode = true;
            // 
            // XepHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 793);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XepHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Xếp Hạng";
            this.Load += new System.EventHandler(this.XepHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCauDungNhieuNhat;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnNhanhNhat;
        private System.Windows.Forms.Button btnTongTaiSan;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}