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
    public partial class QuanLyNhanVien : Form
    {
        DBConnect_Khai db = new DBConnect_Khai();
        public QuanLyNhanVien()
        {
            InitializeComponent();
            LoadListView();
        }
        private void LoadListView()
        {
            lstvDSNV.Items.Clear();
            string truyvan = "select * from NhanVien";
            SqlDataReader reader = db.getDataReader(truyvan);
            while (reader.Read())
            {
                string MaKH = reader["MaNhanVien"].ToString();
                string TenKH = reader["TenNhanVien"].ToString();
                string SDT = reader["SoDienThoai"].ToString();
                string Email = reader["Email"].ToString();
                string DiaChi = reader["DiaChi"].ToString();
                string GioiTinh = reader["GioiTinh"].ToString();
                string ChucVu = reader["ChucVu"].ToString();
                ListViewItem item = new ListViewItem(new[] { MaKH, TenKH, SDT, Email, DiaChi, GioiTinh, ChucVu });
                lstvDSNV.Items.Add(item);
            }
            db.Close();
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNhanVien form = new ThemNhanVien();
            form.ShowDialog();
            LoadListView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (lstvDSNV.SelectedItems.Count > 0)
            {
                string MaNhanVien = lstvDSNV.SelectedItems[0].SubItems[0].Text;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string truyvan = "DELETE FROM NhanVien WHERE MaNhanVien = '" + MaNhanVien + "'";
                        int kq = db.Kq(truyvan);
                        if (kq != 0)
                        {

                            LoadListView();
                            MessageBox.Show("Xóa nhân viên thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa nhân viên");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không Xóa Được nhân viên");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DisplayResultsInListView(DataTable dataTable)
        {
            // Xóa dữ liệu cũ trong ListView
            lstvDSNV.Items.Clear();

            // Hiển thị kết quả trong ListView
            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNhanVien"].ToString());
                item.SubItems.Add(row["TenNhanVien"].ToString());
                item.SubItems.Add(row["SoDienThoai"].ToString());
                item.SubItems.Add(row["Email"].ToString());
                item.SubItems.Add(row["DiaChi"].ToString());
                item.SubItems.Add(row["GioiTinh"].ToString());
                item.SubItems.Add(row["ChucVu"].ToString());
                lstvDSNV.Items.Add(item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != string.Empty)
            {
                string searchQuery = "EXEC SearchNhanVien @SearchTerm = N'" + txtTimKiem.Text + "'";
                DataTable resultTable = db.getDaTaTable(searchQuery);
                DisplayResultsInListView(resultTable);
            }
            else
            {
                LoadListView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lstvDSNV.SelectedItems.Count > 0)
            {
                string MaNV = lstvDSNV.SelectedItems[0].SubItems[0].Text;
                SuaNhanVien form = new SuaNhanVien(MaNV);
                form.ShowDialog();
                LoadListView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
