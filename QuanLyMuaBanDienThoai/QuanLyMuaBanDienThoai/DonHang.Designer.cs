namespace QuanLyMuaBanDienThoai
{
    partial class DonHang
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
            this.btnLammoi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTinhtongtien = new System.Windows.Forms.Button();
            this.txtMakhtinhtt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongtienKh = new System.Windows.Forms.TextBox();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDonhang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTaomadon = new System.Windows.Forms.Button();
            this.cboMakhachhang = new System.Windows.Forms.ComboBox();
            this.txtTrangthai = new System.Windows.Forms.TextBox();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.txtNgaydat = new System.Windows.Forms.TextBox();
            this.txtMadonhang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonhang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLammoi
            // 
            this.btnLammoi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLammoi.Location = new System.Drawing.Point(285, 398);
            this.btnLammoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(170, 35);
            this.btnLammoi.TabIndex = 25;
            this.btnLammoi.Text = "Làm mới bảng";
            this.btnLammoi.UseVisualStyleBackColor = true;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 334);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tổng tiền của một khách hàng";
            // 
            // btnTinhtongtien
            // 
            this.btnTinhtongtien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhtongtien.Location = new System.Drawing.Point(701, 358);
            this.btnTinhtongtien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTinhtongtien.Name = "btnTinhtongtien";
            this.btnTinhtongtien.Size = new System.Drawing.Size(141, 35);
            this.btnTinhtongtien.TabIndex = 22;
            this.btnTinhtongtien.Text = "Tính tổng tiền";
            this.btnTinhtongtien.UseVisualStyleBackColor = true;
            this.btnTinhtongtien.Click += new System.EventHandler(this.btnTinhtongtien_Click);
            // 
            // txtMakhtinhtt
            // 
            this.txtMakhtinhtt.Location = new System.Drawing.Point(211, 363);
            this.txtMakhtinhtt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMakhtinhtt.Name = "txtMakhtinhtt";
            this.txtMakhtinhtt.Size = new System.Drawing.Size(444, 26);
            this.txtMakhtinhtt.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 290);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(779, 27);
            this.label6.TabIndex = 20;
            this.label6.Text = "(*) Nếu tìm kiếm theo ngày thì dùng định dạng năm-tháng-ngày VD:2023-20-10";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.Location = new System.Drawing.Point(872, 250);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(112, 35);
            this.btnTimkiem.TabIndex = 19;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Location = new System.Drawing.Point(382, 255);
            this.txtTimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(444, 26);
            this.txtTimkiem.TabIndex = 18;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(1048, 695);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 35);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(636, 695);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 35);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(191, 695);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 35);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TONGTIEN";
            this.Column5.HeaderText = "Tổng tiền";
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TRANGTHAI";
            this.Column4.HeaderText = "Trạng thái";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NGAYDATHANG";
            this.Column3.HeaderText = "Ngày đặt";
            this.Column3.Name = "Column3";
            // 
            // txtTongtienKh
            // 
            this.txtTongtienKh.Enabled = false;
            this.txtTongtienKh.Location = new System.Drawing.Point(891, 363);
            this.txtTongtienKh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTongtienKh.Name = "txtTongtienKh";
            this.txtTongtienKh.Size = new System.Drawing.Size(235, 26);
            this.txtTongtienKh.TabIndex = 24;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MAKHACHHANG";
            this.Column2.HeaderText = "Mã khách hàng";
            this.Column2.Name = "Column2";
            // 
            // dgvDonhang
            // 
            this.dgvDonhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonhang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvDonhang.Location = new System.Drawing.Point(285, 443);
            this.dgvDonhang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDonhang.Name = "dgvDonhang";
            this.dgvDonhang.Size = new System.Drawing.Size(813, 231);
            this.dgvDonhang.TabIndex = 14;
            this.dgvDonhang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonhang_CellClick);
            this.dgvDonhang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonhang_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MADONHANG";
            this.Column1.HeaderText = "Mã đơn hàng";
            this.Column1.Name = "Column1";
            // 
            // btnTaomadon
            // 
            this.btnTaomadon.Location = new System.Drawing.Point(583, 141);
            this.btnTaomadon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTaomadon.Name = "btnTaomadon";
            this.btnTaomadon.Size = new System.Drawing.Size(213, 52);
            this.btnTaomadon.TabIndex = 11;
            this.btnTaomadon.Text = "Tạo mã đơn hàng mới";
            this.btnTaomadon.UseVisualStyleBackColor = true;
            this.btnTaomadon.Click += new System.EventHandler(this.btnTaomadon_Click);
            // 
            // cboMakhachhang
            // 
            this.cboMakhachhang.FormattingEnabled = true;
            this.cboMakhachhang.Location = new System.Drawing.Point(653, 37);
            this.cboMakhachhang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMakhachhang.Name = "cboMakhachhang";
            this.cboMakhachhang.Size = new System.Drawing.Size(246, 33);
            this.cboMakhachhang.TabIndex = 1;
            // 
            // txtTrangthai
            // 
            this.txtTrangthai.Location = new System.Drawing.Point(653, 83);
            this.txtTrangthai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrangthai.Name = "txtTrangthai";
            this.txtTrangthai.Size = new System.Drawing.Size(249, 33);
            this.txtTrangthai.TabIndex = 3;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(155, 141);
            this.txtTongtien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(242, 33);
            this.txtTongtien.TabIndex = 4;
            this.txtTongtien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongtien_KeyPress);
            // 
            // txtNgaydat
            // 
            this.txtNgaydat.Location = new System.Drawing.Point(155, 89);
            this.txtNgaydat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNgaydat.Name = "txtNgaydat";
            this.txtNgaydat.Size = new System.Drawing.Size(242, 33);
            this.txtNgaydat.TabIndex = 2;
            this.txtNgaydat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNgaydat_KeyPress);
            this.txtNgaydat.Leave += new System.EventHandler(this.txtNgaydat_Leave);
            // 
            // txtMadonhang
            // 
            this.txtMadonhang.Enabled = false;
            this.txtMadonhang.Location = new System.Drawing.Point(155, 42);
            this.txtMadonhang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMadonhang.Name = "txtMadonhang";
            this.txtMadonhang.Size = new System.Drawing.Size(242, 33);
            this.txtMadonhang.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tổng tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trạng thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày đặt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTaomadon);
            this.groupBox1.Controls.Add(this.cboMakhachhang);
            this.groupBox1.Controls.Add(this.txtTrangthai);
            this.groupBox1.Controls.Add(this.txtTongtien);
            this.groupBox1.Controls.Add(this.txtNgaydat);
            this.groupBox1.Controls.Add(this.txtMadonhang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(198, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(938, 227);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn hàng";
            // 
            // DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 744);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnTinhtongtien);
            this.Controls.Add(this.txtMakhtinhtt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTongtienKh);
            this.Controls.Add(this.dgvDonhang);
            this.Controls.Add(this.groupBox1);
            this.Name = "DonHang";
            this.Text = "DonHang";
            this.Load += new System.EventHandler(this.DonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonhang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTinhtongtien;
        private System.Windows.Forms.TextBox txtMakhtinhtt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox txtTongtienKh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dgvDonhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnTaomadon;
        private System.Windows.Forms.ComboBox cboMakhachhang;
        private System.Windows.Forms.TextBox txtTrangthai;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.TextBox txtNgaydat;
        private System.Windows.Forms.TextBox txtMadonhang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}