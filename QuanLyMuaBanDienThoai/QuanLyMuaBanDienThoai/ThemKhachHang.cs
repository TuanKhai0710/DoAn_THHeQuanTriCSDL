using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMuaBanDienThoai
{
    public partial class ThemKhachHang : Form
    {
        DBConnect_Khai db = new DBConnect_Khai();
        public ThemKhachHang()
        {
            InitializeComponent();
        }

        private void ThemKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
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
            if (errorProvider1.GetError(txtHoTen) == "" && errorProvider2.GetError(txtSDT) == "" &&
                errorProvider3.GetError(txtEmail) == "" && errorProvider4.GetError(txtDiaChi) == "")
            {
                try
                {
                    string gt = string.Empty;
                    if (radNam.Checked == true)
                        gt = radNam.Text;
                    else
                        gt = radNu.Text;
                    // Gọi thủ tục lưu trữ SQL Server để thêm khách hàng mới
                    string truyvan = "EXEC AddCustomer @TenKhachHang = N'" + txtHoTen.Text + "', @SoDienThoai = '" + txtSDT.Text + "', @Email = '" + txtEmail.Text + "', @DiaChi = N'" + txtDiaChi.Text + "', @GioiTinh = N'" + gt + "'; ";

                    // Thực hiện câu lệnh gọi thủ tục
                    int kq = db.Kq(truyvan);
                    if (kq != 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy thông tin mã khách hàng mới.");
                    }
                    db.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng");
                }
            }
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
    }
}
