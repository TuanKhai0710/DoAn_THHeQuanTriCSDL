namespace QuanLyMuaBanDienThoai
{
    partial class NhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaCungCap));
            this.DONGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MANCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NGAYNHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_MaNCC = new System.Windows.Forms.ComboBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TenNCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DONGIA
            // 
            this.DONGIA.DataPropertyName = "DIACHI";
            this.DONGIA.HeaderText = "Địa chỉ";
            this.DONGIA.Name = "DONGIA";
            // 
            // SOLUONG
            // 
            this.SOLUONG.DataPropertyName = "TENNCC";
            this.SOLUONG.HeaderText = "Tên nhà cung cấp";
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.Width = 140;
            // 
            // MANCC
            // 
            this.MANCC.DataPropertyName = "MANCC";
            this.MANCC.HeaderText = "Mã nhà cung cấp";
            this.MANCC.Name = "MANCC";
            this.MANCC.Width = 180;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MANCC,
            this.SOLUONG,
            this.DONGIA,
            this.NGAYNHAP});
            this.dataGridView1.Location = new System.Drawing.Point(53, 60);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1171, 225);
            this.dataGridView1.TabIndex = 47;
            // 
            // NGAYNHAP
            // 
            this.NGAYNHAP.DataPropertyName = "SODIENTHOAI";
            this.NGAYNHAP.HeaderText = "Số điện thoại";
            this.NGAYNHAP.Name = "NGAYNHAP";
            this.NGAYNHAP.Width = 140;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 313);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1268, 302);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhà cung cấp";
            // 
            // cbo_MaNCC
            // 
            this.cbo_MaNCC.FormattingEnabled = true;
            this.cbo_MaNCC.Location = new System.Drawing.Point(326, 50);
            this.cbo_MaNCC.Name = "cbo_MaNCC";
            this.cbo_MaNCC.Size = new System.Drawing.Size(283, 35);
            this.cbo_MaNCC.TabIndex = 43;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SDT.Location = new System.Drawing.Point(899, 98);
            this.txt_SDT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(325, 35);
            this.txt_SDT.TabIndex = 42;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DiaChi.Location = new System.Drawing.Point(899, 34);
            this.txt_DiaChi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(325, 35);
            this.txt_DiaChi.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 27);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tên nhà cung cấp";
            // 
            // txt_TenNCC
            // 
            this.txt_TenNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenNCC.Location = new System.Drawing.Point(325, 101);
            this.txt_TenNCC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_TenNCC.Name = "txt_TenNCC";
            this.txt_TenNCC.Size = new System.Drawing.Size(283, 35);
            this.txt_TenNCC.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(785, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 27);
            this.label3.TabIndex = 38;
            this.label3.Text = "Địa chỉ";
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.Location = new System.Drawing.Point(708, 247);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(115, 55);
            this.btn_Them.TabIndex = 65;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.Location = new System.Drawing.Point(855, 247);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(111, 55);
            this.btn_Xoa.TabIndex = 66;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sua.Image")));
            this.btn_Sua.Location = new System.Drawing.Point(994, 247);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(105, 55);
            this.btn_Sua.TabIndex = 67;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_MaNCC);
            this.groupBox2.Controls.Add(this.txt_SDT);
            this.groupBox2.Controls.Add(this.txt_DiaChi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_TenNCC);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1268, 177);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhà cung cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(729, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 27);
            this.label4.TabIndex = 39;
            this.label4.Text = "Số điện thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 27);
            this.label1.TabIndex = 36;
            this.label1.Text = "Mã nhà cung cấp";
            // 
            // NhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 641);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.groupBox2);
            this.Name = "NhaCungCap";
            this.Text = "NhaCungCap";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn DONGIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANCC;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYNHAP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_MaNCC;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenNCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}