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
    public partial class NhapKho : Form
    {
        public NhapKho()
        {
            InitializeComponent();
        }
        DBConnect_Khai db = new DBConnect_Khai();
        DataTable dt;
        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        void HienthiDSNhapKho()
        {
            string chuoitruyvan = "Select * from NHAPKHO";
            dt = db.getDaTaTable(chuoitruyvan);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            dataGridView1.DataSource = dt;
        }
        void Databingding(DataTable pDT)
        {
            txt_MaNhapKho.DataBindings.Clear();
            cbo_MaKho.DataBindings.Clear();
            cbo_MaSP.DataBindings.Clear();
            txt_DonGia.DataBindings.Clear();
            numUD_SoLuong.DataBindings.Clear();
            txt_MaNCC.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            txt_MaNhapKho.DataBindings.Add("Text", pDT, "MANHAPKHO");
            cbo_MaKho.DataBindings.Add("Text", pDT, "MAKHO");
            cbo_MaSP.DataBindings.Add("Text", pDT, "MASANPHAM");
            txt_DonGia.DataBindings.Add("Text", pDT, "DONGIA");
            numUD_SoLuong.DataBindings.Add("Text", pDT, "SOLUONG");
            dateTimePicker1.DataBindings.Add("Text", pDT, "NGAYNHAP");
            txt_MaNCC.DataBindings.Add("Text", pDT, "MANCC");
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
        private void NhapKho_Load(object sender, EventArgs e)
        {
            HienthiDSNhapKho();
            hienThiDSMaSP_cbo();
            hienThiDSMaKho_cbo();
            Databingding(dt);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string MaNhapKho = txt_MaNhapKho.Text;
            string MaSanPham = cbo_MaSP.Text;
            string MaKho = cbo_MaKho.Text;
            string SoLuong = numUD_SoLuong.Text;
            string DonGia = txt_DonGia.Text;
            string NgayNhap = dateTimePicker1.Text;
            string MaNCC = txt_MaNCC.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_ThemNhapKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhapKho", MaNhapKho);
                    cmd.Parameters.AddWithValue("@MaSP", MaSanPham);
                    cmd.Parameters.AddWithValue("@MaKho", MaKho);
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", DonGia);
                    cmd.Parameters.AddWithValue("@NgayNhap", NgayNhap);
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã thêm");
                    else
                        MessageBox.Show("Thêm chưa thành công!");
                    txt_MaNhapKho.Clear();
                    txt_DonGia.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSNhapKho();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string MaNhapKho = txt_MaNhapKho.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("XoaNhapKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhapKho", MaNhapKho);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Sai! vui lòng nhập đúng mã");
                    txt_MaNhapKho.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSNhapKho();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string MaNhapKho = txt_MaNhapKho.Text;
            string MaSanPham = cbo_MaSP.Text;
            string MaKho = cbo_MaKho.Text;
            string SoLuong = numUD_SoLuong.Text;
            string DonGia = txt_DonGia.Text;
            string NgayNhap = dateTimePicker1.Text;
            string MaNCC = txt_MaNCC.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("SuaThongTinKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSP", MaSanPham);
                    cmd.Parameters.AddWithValue("@MaKho", MaKho);
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", DonGia);
                    cmd.Parameters.AddWithValue("@NgayNhap", NgayNhap);
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã cập nhật thông tin nhập kho thành công");
                    else
                        MessageBox.Show("Sai! vui lòng nhập mã đúng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSNhapKho();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string MaNhapKho = txt_MaNhapKho.Text;
            string MaSanPham = cbo_MaSP.SelectedValue.ToString();
            string MaKho = cbo_MaKho.SelectedValue.ToString();
            string SoLuong = numUD_SoLuong.Text;
            string DonGia = txt_DonGia.Text;
            string NgayNhap = dateTimePicker1.Text;
            string MaNCC = txt_MaNCC.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemNhapKho(@MaNhapKho)", connection);
                    cmd.Parameters.AddWithValue("@MaNhapKho", MaNhapKho);
                    cmd.Parameters.AddWithValue("@MaSP", MaSanPham);
                    cmd.Parameters.AddWithValue("@MaKho", MaKho);
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", DonGia);
                    cmd.Parameters.AddWithValue("@NgayNhap", NgayNhap);
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
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
