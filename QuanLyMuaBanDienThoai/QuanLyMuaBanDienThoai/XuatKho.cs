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
    public partial class XuatKho : Form
    {
        public XuatKho()
        {
            InitializeComponent();
        }
        DBConnect_Khai db = new DBConnect_Khai();
        DataTable dt;
        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        void HienthiDSXuatKho()
        {
            string chuoitruyvan = "Select * from XUATKHO";
            dt = db.getDaTaTable(chuoitruyvan);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            dataGridView1.DataSource = dt;
        }
        void hienThiDSMaSP_cbo()
        {
            DBConnect_Khai db = new DBConnect_Khai();
            string chuoitruyvan = "Select * from SANPHAM";
            DataTable dt = db.getDaTaTable(chuoitruyvan);

            cbo_MaSP.DataSource = dt;
            cbo_MaSP.DisplayMember = "MASANPHAM";
            cbo_MaSP.ValueMember = "MASANPHAM";
        }
        void hienThiDSMaKho_cbo()
        {
            DBConnect_Khai db = new DBConnect_Khai();
            string chuoitruyvan = "Select * from KHO";
            DataTable dt = db.getDaTaTable(chuoitruyvan);

            cbo_MaKho.DataSource = dt;
            cbo_MaKho.DisplayMember = "MAKHO";
            cbo_MaKho.ValueMember = "MAKHO";
        }
        void Databingding(DataTable pDT)
        {
            txt_MaXuatKho.DataBindings.Clear();
            cbo_MaKho.DataBindings.Clear();
            cbo_MaSP.DataBindings.Clear();
            numUD_SoLuong.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            txt_MaXuatKho.DataBindings.Add("Text", pDT, "MAXUATKHO");
            cbo_MaKho.DataBindings.Add("Text", pDT, "MAKHO");
            cbo_MaSP.DataBindings.Add("Text", pDT, "MASANPHAM");
            numUD_SoLuong.DataBindings.Add("Text", pDT, "SOLUONG");
            dateTimePicker1.DataBindings.Add("Text", pDT, "NGAYXUAT");
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
           string MaXuatKho = txt_MaXuatKho.Text;
           string MaSanPham = cbo_MaSP.SelectedValue.ToString(); // Lấy giá trị được chọn từ ComboBox
           string MaKho = cbo_MaKho.SelectedValue.ToString(); ; // Lấy giá trị được chọn từ ComboBox
           int SoLuong = (int)numUD_SoLuong.Value; // Lấy giá trị từ Numeric Up/Down Control
           string NgayXuat = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Định dạng ngày tháng

        try
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemXuatKho", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaXuatKho", MaXuatKho);
                cmd.Parameters.AddWithValue("@MaSP", MaSanPham);
                cmd.Parameters.AddWithValue("@MaKho", MaKho);
                cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                cmd.Parameters.AddWithValue("@NgayXuat", NgayXuat);

                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                    MessageBox.Show("Đã thêm");
                else
                    MessageBox.Show("Thêm chưa thành công!");
                txt_MaXuatKho.Clear();
                txt_DonGia.Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }
        HienthiDSXuatKho();
    }
        private void XuatKho_Load(object sender, EventArgs e)
        {
            HienthiDSXuatKho();
            hienThiDSMaSP_cbo();
            hienThiDSMaKho_cbo();
            Databingding(dt);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string MaXuatKho = txt_MaXuatKho.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("XoaXuatKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaXuatKho", MaXuatKho);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Sai! vui lòng nhập đúng mã");
                    txt_MaXuatKho.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSXuatKho();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string MaXuatKho = txt_MaXuatKho.Text;
            string MaSanPham = cbo_MaSP.Text;
            string MaKho1 = cbo_MaKho.Text;
            string SoLuong = numUD_SoLuong.Text;
            string NgayXuat = dateTimePicker1.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("SuaThongTinKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaXuatKho", MaXuatKho);
                    cmd.Parameters.AddWithValue("@MaSP", MaSanPham);
                    cmd.Parameters.AddWithValue("@MaKho", MaKho1);
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                    cmd.Parameters.AddWithValue("@NgayXuat", NgayXuat);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã cập nhật thông tin xuất kho thành công");
                    else
                        MessageBox.Show("Sai! vui lòng nhập mã đúng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSXuatKho();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string MaXuatKho = txt_MaXuatKho.Text;
            string MaSanPham = cbo_MaSP.Text;
            string MaKho1 = cbo_MaKho.Text;
            string SoLuong = numUD_SoLuong.Text;
            string NgayXuat = dateTimePicker1.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemXuatKho(@MaXuatKho)", connection);
                    cmd.Parameters.AddWithValue("@MaXuatKho", MaXuatKho);
                    cmd.Parameters.AddWithValue("@MaSP", MaSanPham);
                    cmd.Parameters.AddWithValue("@MaKho", MaKho1);
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                    cmd.Parameters.AddWithValue("@NgayXuat", NgayXuat);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    connection.Open();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

    }
}
