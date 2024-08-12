namespace QuanLyMuaBanDienThoai
{
    partial class XuatKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XuatKho));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.cbo_MaKho = new System.Windows.Forms.ComboBox();
            this.cbo_MaSP = new System.Windows.Forms.ComboBox();
            this.numUD_SoLuong = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MaXuatKho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_DonGia = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.MAXUATKHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MASANPHAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYXUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SoLuong)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(104, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1301, 352);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách xuất kho";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAXUATKHO,
            this.MASANPHAM,
            this.MAKHO,
            this.SOLUONG,
            this.NGAYXUAT});
            this.dataGridView1.Location = new System.Drawing.Point(46, 60);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1189, 246);
            this.dataGridView1.TabIndex = 49;
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.Location = new System.Drawing.Point(777, 327);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(112, 61);
            this.btn_Them.TabIndex = 30;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.Location = new System.Drawing.Point(911, 327);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(111, 61);
            this.btn_Xoa.TabIndex = 31;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sua.Image")));
            this.btn_Sua.Location = new System.Drawing.Point(1043, 327);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(112, 61);
            this.btn_Sua.TabIndex = 32;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // cbo_MaKho
            // 
            this.cbo_MaKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_MaKho.FormattingEnabled = true;
            this.cbo_MaKho.Location = new System.Drawing.Point(218, 178);
            this.cbo_MaKho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_MaKho.Name = "cbo_MaKho";
            this.cbo_MaKho.Size = new System.Drawing.Size(364, 35);
            this.cbo_MaKho.TabIndex = 51;
            // 
            // cbo_MaSP
            // 
            this.cbo_MaSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_MaSP.FormattingEnabled = true;
            this.cbo_MaSP.Location = new System.Drawing.Point(218, 111);
            this.cbo_MaSP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_MaSP.Name = "cbo_MaSP";
            this.cbo_MaSP.Size = new System.Drawing.Size(364, 35);
            this.cbo_MaSP.TabIndex = 50;
            // 
            // numUD_SoLuong
            // 
            this.numUD_SoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUD_SoLuong.Location = new System.Drawing.Point(857, 46);
            this.numUD_SoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.numUD_SoLuong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUD_SoLuong.Name = "numUD_SoLuong";
            this.numUD_SoLuong.Size = new System.Drawing.Size(258, 35);
            this.numUD_SoLuong.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(738, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 27);
            this.label7.TabIndex = 46;
            this.label7.Text = "Ngày xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(738, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 27);
            this.label6.TabIndex = 45;
            this.label6.Text = "Đơn giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(738, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 27);
            this.label5.TabIndex = 44;
            this.label5.Text = "Số lượng";
            // 
            // txt_MaXuatKho
            // 
            this.txt_MaXuatKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaXuatKho.Location = new System.Drawing.Point(218, 48);
            this.txt_MaXuatKho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_MaXuatKho.Name = "txt_MaXuatKho";
            this.txt_MaXuatKho.Size = new System.Drawing.Size(364, 35);
            this.txt_MaXuatKho.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 27);
            this.label3.TabIndex = 42;
            this.label3.Text = "Mã kho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 27);
            this.label2.TabIndex = 41;
            this.label2.Text = "Mã sẳn phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 27);
            this.label1.TabIndex = 40;
            this.label1.Text = "Mã xuất kho";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(857, 179);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(257, 30);
            this.dateTimePicker1.TabIndex = 48;
            // 
            // txt_DonGia
            // 
            this.txt_DonGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DonGia.Location = new System.Drawing.Point(856, 111);
            this.txt_DonGia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_DonGia.Name = "txt_DonGia";
            this.txt_DonGia.Size = new System.Drawing.Size(258, 35);
            this.txt_DonGia.TabIndex = 47;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_MaXuatKho);
            this.groupBox2.Controls.Add(this.cbo_MaKho);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numUD_SoLuong);
            this.groupBox2.Controls.Add(this.cbo_MaSP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_DonGia);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(104, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1301, 248);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin xuất kho";
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tim.Image")));
            this.btn_Tim.Location = new System.Drawing.Point(647, 330);
            this.btn_Tim.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(110, 58);
            this.btn_Tim.TabIndex = 55;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // MAXUATKHO
            // 
            this.MAXUATKHO.DataPropertyName = "MAXUATKHO";
            this.MAXUATKHO.HeaderText = "Mã xuất kho";
            this.MAXUATKHO.Name = "MAXUATKHO";
            this.MAXUATKHO.Width = 150;
            // 
            // MASANPHAM
            // 
            this.MASANPHAM.DataPropertyName = "MASANPHAM";
            this.MASANPHAM.HeaderText = "Mã sẳn phẩm";
            this.MASANPHAM.Name = "MASANPHAM";
            this.MASANPHAM.Width = 150;
            // 
            // MAKHO
            // 
            this.MAKHO.DataPropertyName = "MAKHO";
            this.MAKHO.HeaderText = "Mã kho";
            this.MAKHO.Name = "MAKHO";
            // 
            // SOLUONG
            // 
            this.SOLUONG.DataPropertyName = "SOLUONG";
            this.SOLUONG.HeaderText = "SOLUONG";
            this.SOLUONG.Name = "SOLUONG";
            // 
            // NGAYXUAT
            // 
            this.NGAYXUAT.DataPropertyName = "NGAYXUAT";
            this.NGAYXUAT.HeaderText = "Ngày xuất";
            this.NGAYXUAT.Name = "NGAYXUAT";
            this.NGAYXUAT.Width = 140;
            // 
            // XuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 641);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "XuatKho";
            this.Text = "XuatKho";
            this.Load += new System.EventHandler(this.XuatKho_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SoLuong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.ComboBox cbo_MaKho;
        private System.Windows.Forms.ComboBox cbo_MaSP;
        private System.Windows.Forms.NumericUpDown numUD_SoLuong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MaXuatKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_DonGia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAXUATKHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASANPHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYXUAT;
    }
}