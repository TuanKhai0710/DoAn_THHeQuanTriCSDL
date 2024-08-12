using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyMuaBanDienThoai
{
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }
        DBConnect_Khai db = new DBConnect_Khai();
        DataTable dt;
        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        void HienthiDSNCC()
        {
            string chuoitruyvan = "Select * from NHACUNGCAP";
            dt = db.getDaTaTable(chuoitruyvan);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            dataGridView1.DataSource = dt;
        }
        void Databingding(DataTable pDT)
        {
            cbo_MaNCC.DataBindings.Clear();
            txt_TenNCC.DataBindings.Clear();
            txt_DiaChi.DataBindings.Clear();
            txt_SDT.DataBindings.Clear();
            cbo_MaNCC.DataBindings.Add("Text", pDT, "MANCC");
            txt_TenNCC.DataBindings.Add("Text", pDT, "TENNCC");
            txt_DiaChi.DataBindings.Add("Text", pDT, "DIACHI");
            txt_SDT.DataBindings.Add("Text", pDT, "SODIENTHOAI");
        }
        void hienThiDSMaNCC_cbo()
        {
            DBConnect_Khai db = new DBConnect_Khai();
            string chuoitruyvan = "Select * from NHACUNGCAP";
            DataTable dt = db.getDaTaTable(chuoitruyvan);

            cbo_MaNCC.DataSource = dt;
            cbo_MaNCC.DisplayMember = "MANCC";
            cbo_MaNCC.ValueMember = "MANCC";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string MaNCC = cbo_MaNCC.Text;
            string TenNCC = txt_TenNCC.Text;
            string DiaChi = txt_DiaChi.Text;
            string SDT = txt_SDT.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_ThemNCC", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", TenNCC);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@SoDienThoai", SDT);
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã thêm");
                    else
                        MessageBox.Show("Thêm chưa thành công!");
                    txt_TenNCC.Clear();
                    txt_DiaChi.Clear();
                    txt_SDT.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSNCC();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            HienthiDSNCC();
            Databingding(dt);
            hienThiDSMaNCC_cbo();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string MaNCC = cbo_MaNCC.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("XoaNCC", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Sai! vui lòng nhập đúng mã");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSNCC();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string MaNCC = cbo_MaNCC.Text;
            string TenNCC = txt_TenNCC.Text;
            string DiaChi = txt_DiaChi.Text;
            string SDT = txt_SDT.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("SuaThongTinNhaCungCap", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", TenNCC);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@SoDienThoai", SDT);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã cập nhật thông tin nhà cung cấp thành công");
                    else
                        MessageBox.Show("Sai! vui lòng nhập mã đúng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSNCC();
        }
    }
}
