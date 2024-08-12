using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace QuanLyMuaBanDienThoai
{
    public partial class DonHang : Form
    {
        public DonHang()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DBConnect_Khai db = new DBConnect_Khai();
        //string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        SqlConnection connection = new SqlConnection("Data Source=MSI/SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123");
        void load_GrdDh()
        {
            string sql = "select * from DONHANG";
            dt = db.getDaTaTable(sql);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
        }
        void load_cboMakh()
        {
            string cboMakh = "select * from KHACHHANG";
            DataTable dt = new DataTable();
            dt = db.getDaTaTable(cboMakh);
            cboMakhachhang.DataSource = dt;
            cboMakhachhang.ValueMember = "MAKHACHHANG";
            cboMakhachhang.DisplayMember = "TENKHACHHANG";
        }


        private void DonHang_Load(object sender, EventArgs e)
        {
            load_GrdDh();
            dgvDonhang.DataSource = dt;
            load_cboMakh();
            cboMakhachhang.SelectedValue = -1;
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            load_GrdDh();
            dgvDonhang.DataSource = dt;
        }

        private void dgvDonhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvDonhang.CurrentRow.Index;
            txtMadonhang.Text = dgvDonhang.Rows[index].Cells[0].Value.ToString();
            cboMakhachhang.SelectedValue = dgvDonhang.Rows[index].Cells[1].Value.ToString();
            txtNgaydat.Text = dgvDonhang.Rows[index].Cells[2].Value.ToString();
            txtTrangthai.Text = dgvDonhang.Rows[index].Cells[3].Value.ToString();
            txtTongtien.Text = dgvDonhang.Rows[index].Cells[4].Value.ToString();
        }

        private void dgvDonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvDonhang.CurrentRow.Index;
            txtMadonhang.Text = dgvDonhang.Rows[index].Cells[0].Value.ToString();
            cboMakhachhang.SelectedValue = dgvDonhang.Rows[index].Cells[1].Value.ToString();
            txtNgaydat.Text = dgvDonhang.Rows[index].Cells[2].Value.ToString();
            txtTrangthai.Text = dgvDonhang.Rows[index].Cells[3].Value.ToString();
            txtTongtien.Text = dgvDonhang.Rows[index].Cells[4].Value.ToString();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimkiem.Text;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SearchDonHang", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDonhang.DataSource = dt;
                }
            }
            connection.Close();
        }

        private void btnTaomadon_Click(object sender, EventArgs e)
        {
            string truyvan = "select top 1 MADONHANG from DONHANG order by MADONHANG DESC";
            SqlDataReader read = db.getDataReader(truyvan);
            if (read.Read())
            {
                string lastMhd = read["MADONHANG"].ToString();
                int kq = int.Parse(lastMhd.Substring(2));
                kq++;
                string newMahd = "DH" + kq.ToString("D3");
                txtMadonhang.Text = newMahd;
                db.Close();
            }
            else
            {
                txtMadonhang.Text = "HD001";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("InsertDonHang", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (txtMadonhang.Text == string.Empty)
                {
                    MessageBox.Show("Không được để trống mã đơn hàng!! Nhấn nút tạo mã ở dưới để tạo mới");
                }
                else if (cboMakhachhang.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng");
                }
                else if (txtNgaydat.Text == string.Empty)
                {
                    MessageBox.Show("Không được để trống ngày đặt");
                }
                else if (txtTrangthai.Text == string.Empty)
                {
                    MessageBox.Show("Không được để trống trạng thái");
                }
                else if (txtTrangthai.Text != "Chưa xử lý" && txtTrangthai.Text != "Đã xử lý")
                {
                    MessageBox.Show("Trạng thái chỉ chấp nhận Đã xử lý hoặc Chưa xử lý");
                }
                else if (!db.ktraMaDonHang(txtMadonhang.Text))
                {
                    cmd.Parameters.AddWithValue("@MaDonHang", txtMadonhang.Text);
                    cmd.Parameters.AddWithValue("@MaKhachHang", cboMakhachhang.SelectedValue);
                    cmd.Parameters.AddWithValue("@NgayDatHang", txtNgaydat.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", txtTrangthai.Text);
                    cmd.Parameters.AddWithValue("@TongTien", txtTongtien.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm đơn hàng thành công.");
                    load_GrdDh();
                    dgvDonhang.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                    txtMadonhang.Clear();
                    cboMakhachhang.SelectedValue = -1;
                    txtNgaydat.Clear();
                    txtTrangthai.Clear();
                    txtTongtien.Clear();
                }
            }
            connection.Close();
        }

        private void btnTinhtongtien_Click(object sender, EventArgs e)
        {
            connection.Open();
            string truyvan = "DECLARE @MaKhachHang CHAR(10) = '" + txtMakhtinhtt.Text + "';SELECT dbo.GetTongTienByMaKhachHang(@MaKhachHang) AS TongTien;";
            SqlCommand command = new SqlCommand(truyvan, connection);
            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                float tongTien = Convert.ToSingle(result);
                txtTongtienKh.Text = tongTien.ToString();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu.");
            }
            connection.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("DeleteDonHang", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (txtMadonhang.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng chọn mã đơn hàng để xóa");
                }
                else
                {
                    string maDonHangToDelete = txtMadonhang.Text;
                    cmd.Parameters.AddWithValue("@MaDonHang", maDonHangToDelete);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã xóa đơn hàng thành công.");
                    load_GrdDh();
                    dgvDonhang.DataSource = dt;
                    txtMadonhang.Clear();
                    cboMakhachhang.SelectedValue = -1;
                    txtNgaydat.Clear();
                    txtTrangthai.Clear();
                    txtTongtien.Clear();
                }
            }
            connection.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("UpdateDonHang", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (txtMadonhang.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng chọn 1 đơn hàng để sửa");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaDonHang", txtMadonhang.Text);
                    cmd.Parameters.AddWithValue("@MaKhachHang", cboMakhachhang.SelectedValue);
                    cmd.Parameters.AddWithValue("@NgayDatHang", txtNgaydat.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", txtTrangthai.Text);
                    cmd.Parameters.AddWithValue("@TongTien", txtTongtien.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã sửa đơn hàng thành công.");
                    load_GrdDh();
                    dgvDonhang.DataSource = dt;
                }
            }
            connection.Close();
        }
        public void kiemNgaydat()
        {
            string input = txtNgaydat.Text;
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            if (!Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Sai định dạng ngày tháng năm. Định dạng đúng: yyyy-MM-dd (VD: 2023-10-28)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaydat.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void txtNgaydat_Leave(object sender, EventArgs e)
        {
            kiemNgaydat();
        }

        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNgaydat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            if (txtNgaydat.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            load_GrdDh();
            dgvDonhang.DataSource = dt;
        }

    }
}
