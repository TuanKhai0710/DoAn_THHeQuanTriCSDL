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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        DataTable dt;
        DBConnect_Khai db = new DBConnect_Khai();
        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        void HienthiDSChiTietSanPham()
        {
            dt = new DataTable();
            string chuoitruyvan = "SELECT MASANPHAM, MACHITIETSANPHAM, TENSANPHAM, GIA, MAUSAC, MOTASANPHAM, HINHANH FROM CHITIETSANPHAM";
            dt = db.getDaTaTable(chuoitruyvan);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            dataGridView1.DataSource = dt;
        }

        void Databinding(DataTable pDT)
        {

            txt_MaSanPham.DataBindings.Clear();
            txt_MaChiTietSP.DataBindings.Clear();
            txt_TenSanPham.DataBindings.Clear();
            txt_Gia.DataBindings.Clear();
            MauSac.DataBindings.Clear();
            txt_MoTa.DataBindings.Clear();
            txt_HinhAnh.DataBindings.Clear();


            txt_MaSanPham.DataBindings.Add("Text", pDT, "MASANPHAM");
            txt_TenSanPham.DataBindings.Add("Text", pDT, "TENSANPHAM");
            txt_MaChiTietSP.DataBindings.Add("Text", pDT, "MACHITIETSANPHAM");
            txt_Gia.DataBindings.Add("Text", pDT, "GIA");
            txt_MauSac.DataBindings.Add("Text", pDT, "MAUSAC");
            txt_MoTa.DataBindings.Add("Text", pDT, "MOTASANPHAM");
            txt_HinhAnh.DataBindings.Add("Text", pDT, "HINHANH");
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string MASANPHAM = txt_MaSanPham.Text;
            string TENSANPHAM = txt_TenSanPham.Text;
            string MACHITIETSANPHAM = txt_MaChiTietSP.Text;
            string GIA = txt_Gia.Text;
            string MAUSAC = txt_MauSac.Text;
            string MOTASANPHAM = txt_MoTa.Text;
            string HINHANH = txt_HinhAnh.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_ThemSanPham", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSanPham", MASANPHAM);
                    cmd.Parameters.AddWithValue("@TenSanPham", TENSANPHAM);
                    cmd.Parameters.AddWithValue("@MaChiTietSanPham", MACHITIETSANPHAM);
                    cmd.Parameters.AddWithValue("@Gia", GIA);
                    cmd.Parameters.AddWithValue("@MauSac", MAUSAC);
                    cmd.Parameters.AddWithValue("@MoTaSanPham", MOTASANPHAM);
                    cmd.Parameters.AddWithValue("@HinhAnh", HINHANH);
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã thêm");
                    else
                        MessageBox.Show("Thêm chưa thành công! Sản Phẩm này đã tồn tại.");
                    txt_MaSanPham.Clear();
                    txt_TenSanPham.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSChiTietSanPham();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            HienthiDSChiTietSanPham();
            Databinding(dt);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string MASANPHAM = txt_MaSanPham.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaSanPham", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSanPham", MASANPHAM);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Sai! vui lòng nhập đúng mã");
                    txt_MaSanPham.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSChiTietSanPham();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string MASANPHAM = txt_MaSanPham.Text;
            string TENSANPHAM = txt_TenSanPham.Text;
            string MACHITIETSANPHAM = txt_MaChiTietSP.Text;
            string GIA = txt_Gia.Text;
            string MAUSAC = txt_MauSac.Text;
            string MOTASANPHAM = txt_MoTa.Text;
            string HINHANH = txt_HinhAnh.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SuaSanPham", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSanPham", MASANPHAM);
                    cmd.Parameters.AddWithValue("@TenSanPham", TENSANPHAM);
                    cmd.Parameters.AddWithValue("@MaChiTietSanPham", MACHITIETSANPHAM);
                    cmd.Parameters.AddWithValue("@Gia", GIA);
                    cmd.Parameters.AddWithValue("@MauSac", MAUSAC);
                    cmd.Parameters.AddWithValue("@MoTaSanPham", MOTASANPHAM);
                    cmd.Parameters.AddWithValue("@HinhAnh", HINHANH);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã cập nhật thông tin nhập kho thành công");
                    else
                        MessageBox.Show("Sai! Sản phẩm không tồn tại vui lòng nhập mã đúng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
        }

        private void btn_locsp_Click(object sender, EventArgs e)
        {
            string MASANPHAM = txt_MaSanPham.Text;
            string TENSANPHAM = txt_TenSanPham.Text;
            string MACHITIETSANPHAM = txt_MaChiTietSP.Text;
            string GIA = txt_Gia.Text;
            string MAUSAC = txt_MauSac.Text;
            string MOTASANPHAM = txt_MoTa.Text;
            string HINHANH = txt_HinhAnh.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    // Sử dụng CommandType.Text để chỉ định rằng bạn đang gọi một hàm SQL
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fc_LocDanhSachSanPhamTheoTenSP(@TenSanPham)", connection);
                    cmd.Parameters.AddWithValue("@MaSanPham", MASANPHAM);
                    cmd.Parameters.AddWithValue("@TenSanPham", TENSANPHAM);
                    cmd.Parameters.AddWithValue("@MaChiTietSanPham", MACHITIETSANPHAM);
                    cmd.Parameters.AddWithValue("@Gia", GIA);
                    cmd.Parameters.AddWithValue("@MauSac", MAUSAC);
                    cmd.Parameters.AddWithValue("@MoTaSanPham", MOTASANPHAM);
                    cmd.Parameters.AddWithValue("@HinhAnh", HINHANH);
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

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string MASANPHAM = txt_MaSanPham.Text;
            string TENSANPHAM = txt_TenSanPham.Text;
            string MACHITIETSANPHAM = txt_MaChiTietSP.Text;
            string GIA = txt_Gia.Text;
            string MAUSAC = txt_MauSac.Text;
            string MOTASANPHAM = txt_MoTa.Text;
            string HINHANH = txt_HinhAnh.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    // Sử dụng CommandType.Text để chỉ định rằng bạn đang gọi một hàm SQL
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fc_LayThongTinChiTietSanPham(@MaSanPham)", connection);
                    cmd.Parameters.AddWithValue("@MaSanPham", MASANPHAM);
                    cmd.Parameters.AddWithValue("@TenSanPham", TENSANPHAM);
                    cmd.Parameters.AddWithValue("@MaChiTietSanPham", MACHITIETSANPHAM);
                    cmd.Parameters.AddWithValue("@Gia", GIA);
                    cmd.Parameters.AddWithValue("@MauSac", MAUSAC);
                    cmd.Parameters.AddWithValue("@MoTaSanPham", MOTASANPHAM);
                    cmd.Parameters.AddWithValue("@HinhAnh", HINHANH);
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
