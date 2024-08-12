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
    public partial class QuanLyKhachHang : Form
    {
        DBConnect_Khai db = new DBConnect_Khai();
        private void LoadListView()
        {
            lstvDSKH.Items.Clear();
            string truyvan = "select * from KHACHHANG";
            SqlDataReader reader = db.getDataReader(truyvan);
            while (reader.Read())
            {
                string MaKH = reader["MAKHACHHANG"].ToString();
                string TenKH = reader["TenKhachHang"].ToString();
                string SDT = reader["SoDienThoai"].ToString();
                string Email = reader["Email"].ToString();
                string DiaChi = reader["DiaChi"].ToString();
                string GioiTinh = reader["GioiTinh"].ToString();
                ListViewItem item = new ListViewItem(new[] { MaKH, TenKH, SDT, Email, DiaChi, GioiTinh });
                lstvDSKH.Items.Add(item);
            }
            db.Close();
        }
        private void LoadDuLieu()
        {
            LoadListView();
        }
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lstvDSKH.SelectedItems.Count > 0)
            {
                string maKhachHang = lstvDSKH.SelectedItems[0].SubItems[0].Text;
                SuaKhachHang form = new SuaKhachHang(maKhachHang);
                form.ShowDialog();
                LoadDuLieu();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemKhachHang form = new ThemKhachHang();
            form.ShowDialog();
            LoadDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvDSKH.SelectedItems.Count > 0)
            {
                string maKhachHang = lstvDSKH.SelectedItems[0].SubItems[0].Text;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string truyvan = "DELETE FROM KHACHHANG WHERE MAKHACHHANG = '" + maKhachHang + "'";
                        int kq = db.Kq(truyvan);
                        if (kq != 0)
                        {

                            LoadListView();
                            MessageBox.Show("Xóa khách hàng thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa khách hàng");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không Xóa Được Khách Hàng");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != string.Empty)
            {
                string searchQuery = "EXEC SearchKhachHang @SearchTerm = N'" + txtTimKiem.Text + "'";
                DataTable resultTable = db.getDaTaTable(searchQuery);
                DisplayResultsInListView(resultTable);
            }
            else
            {
                LoadDuLieu();
            }    
        }
        private void DisplayResultsInListView(DataTable dataTable)
        {
            // Xóa dữ liệu cũ trong ListView
            lstvDSKH.Items.Clear();

            // Hiển thị kết quả trong ListView
            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["MAKHACHHANG"].ToString());
                item.SubItems.Add(row["TENKHACHHANG"].ToString());
                item.SubItems.Add(row["SODIENTHOAI"].ToString());
                item.SubItems.Add(row["EMAIL"].ToString());
                item.SubItems.Add(row["DIACHI"].ToString());
                item.SubItems.Add(row["GIOITINH"].ToString());
                lstvDSKH.Items.Add(item);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
        }
    }
}
