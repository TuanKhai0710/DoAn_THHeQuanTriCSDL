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
    public partial class Kho : Form
    {
        public Kho()
        {
            InitializeComponent();
        }
        DBConnect_Khai db = new DBConnect_Khai();
        DataTable dt;
        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        void HienthiDSKho()
        {
            string chuoitruyvan = "Select MAKHO, TENKHO, DIACHIKHO,SOLUONGSP, SODIENTHOAIKHO from KHO";
            dt = db.getDaTaTable(chuoitruyvan);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            dataGridView1.DataSource = dt;
        }
        void Databingding(DataTable pDT)
        {
            txt_MaKho.DataBindings.Clear();
            txt_TenKho.DataBindings.Clear();
            txt_DiaChiKho.DataBindings.Clear();
            txt_SDTKho.DataBindings.Clear();
            txt_MaKho.DataBindings.Add("Text", pDT, "MAKHO");
            txt_TenKho.DataBindings.Add("Text", pDT, "TENKHO");
            txt_DiaChiKho.DataBindings.Add("Text", pDT, "DIACHIKHO");
            txt_SDTKho.DataBindings.Add("Text", pDT, "SODIENTHOAIKHO");
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            HienthiDSKho();
            Databingding(dt); 
        }

        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            string MaKho = txt_MaKho.Text;
            string TenKho = txt_TenKho.Text;
            string DiaChi = txt_DiaChiKho.Text;
            string SDT = txt_SDTKho.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_ThemKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKho", MaKho);
                    cmd.Parameters.AddWithValue("@TenKho", TenKho);
                    cmd.Parameters.AddWithValue("@DiaChiKho", DiaChi);
                    cmd.Parameters.AddWithValue("@SoDienThoaiKho", SDT);
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã thêm");
                    else
                        MessageBox.Show("Thêm chưa thành công!");
                    txt_MaKho.Clear();
                    txt_TenKho.Clear();
                    txt_DiaChiKho.Clear();
                    txt_SDTKho.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSKho();
        }
        private void btn_Xoa_Click_1(object sender, EventArgs e)
        {
            string MaKho = txt_MaKho.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("XoaKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKho", MaKho);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Sai! vui lòng nhập đúng mã");
                    txt_MaKho.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSKho();
        }

        private void btn_Sua_Click_1(object sender, EventArgs e)
        {
            string MaKho = txt_MaKho.Text;
            string TenKho = txt_TenKho.Text;
            string DiaChi = txt_DiaChiKho.Text;
            string SDT = txt_SDTKho.Text;
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                try
                {
                    SqlCommand cmd = new SqlCommand("SuaThongTinKho", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKho", MaKho);
                    cmd.Parameters.AddWithValue("@TenKho", TenKho);
                    cmd.Parameters.AddWithValue("@DiaChiKho", DiaChi);
                    cmd.Parameters.AddWithValue("@SoDienThoai", SDT);
                    connection.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                        MessageBox.Show("Đã cập nhật thông tin kho thành công");
                    else
                        MessageBox.Show("Sai! vui lòng nhập mã đúng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            HienthiDSKho();
        }
    }
}
