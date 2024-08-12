using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyMuaBanDienThoai
{
    public partial class SuaNhanVien : Form
    {
        string MaNhanVien;
        DBConnect_Khai db = new DBConnect_Khai();
        public SuaNhanVien(string MaNV)
        {
            InitializeComponent();
            MaNhanVien = MaNV;
        }
        public void LoadcboChucVu()
        {
            cboChucVu.Items.Clear();
            cboChucVu.Items.Add("Quản Lý Kho");
            cboChucVu.Items.Add("Nhân Viên Kỹ Thuật");
            cboChucVu.Items.Add("Nhân Viên Bán Hàng");
            cboChucVu.Items.Add("Quản Lý Cửa Hàng");
            cboChucVu.Items.Add("Bảo Vệ");
        }
        void LoadDuLieu()
        {
            string truyvan = "select * from NhanVien WHERE MaNhanVien = '" + MaNhanVien + "'";
            SqlDataReader reader = db.getDataReader(truyvan);
            while (reader.Read())
            {
                txtHoTen.Text = reader["TenNhanVien"].ToString();
                txtSDT.Text = reader["SoDienThoai"].ToString().Trim();
                txtEmail.Text = reader["Email"].ToString();
                txtDiaChi.Text = reader["DiaChi"].ToString();
                string GioiTinh = reader["GioiTinh"].ToString();
                if (GioiTinh == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                    radNu.Checked = true;
                
            }
            db.Close();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return phoneNumber.Length <= 11;
        }

        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            LoadcboChucVu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Vui lòng nhập Họ Tên");
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                errorProvider2.SetError(txtSDT, "Vui lòng nhập Số Điện Thoại");
            }
            else if (!IsValidPhoneNumber(txtSDT.Text))
            {
                errorProvider2.SetError(txtSDT, "Số Điện Thoại không hợp lệ");
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                errorProvider3.SetError(txtEmail, "Vui lòng nhập Email hợp lệ");
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                errorProvider4.SetError(txtDiaChi, "Vui lòng nhập Địa Chỉ");
            }
            if (cboChucVu.SelectedIndex == -1)
            {
                errorProvider5.SetError(cboChucVu, "Vui lòng chọn chức vụ");
            }
            if (errorProvider1.GetError(txtHoTen) == "" && errorProvider2.GetError(txtSDT) == "" &&
                errorProvider3.GetError(txtEmail) == "" && errorProvider4.GetError(txtDiaChi) == "" && errorProvider5.GetError(cboChucVu) == "")
            {
                try
                {
                    string gt = string.Empty;
                    if (radNam.Checked == true)
                        gt = radNam.Text;
                    else
                        gt = radNu.Text;
                    // Gọi thủ tục lưu trữ SQL Server để thêm khách hàng mới
                    string truyvan = "UPDATE NhanVien SET TenNhanVien = N'" + txtHoTen.Text + "',SODIENTHOAI = '" + txtSDT.Text + "', EMAIL ='" + txtEmail.Text + "', DIACHI = N'" + txtDiaChi.Text + "', GIOITINH = N'" + gt + "', ChucVu = N'" + cboChucVu.SelectedItem + "' WHERE MaNhanVien = '" + MaNhanVien + "'";

                    // Thực hiện câu lệnh gọi thủ tục
                    int kq = db.Kq(truyvan);
                    if (kq != 0)
                    {
                        MessageBox.Show("Sửa nhân viên thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin nhân viên mới.");
                    }
                    db.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa nhân viên", ex.Message);
                }
            }
        }
    }
}
