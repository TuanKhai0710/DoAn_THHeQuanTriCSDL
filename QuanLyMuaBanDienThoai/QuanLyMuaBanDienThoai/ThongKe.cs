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
    public partial class ThongKe : Form
    {
        DBConnect_Khai db = new DBConnect_Khai();
        public ThongKe()
        {
            InitializeComponent();
            loadCboThang();
            ThongKeTrangThaiDonHang();
            Top5DonHangCaoNhat();
            TongLuongNhapKhoTrongNam();
            hienThiDSMaKho_cbo();
        }

        private void loadCboThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbo_Thang.Items.Add(i);
            }

            int currentYear = DateTime.Now.Year;
            for (int i = 2015; i <= currentYear; i++)
            {
                cbo_Nam.Items.Add(i);
            }

            cbo_Thang.SelectedIndex = DateTime.Now.Month - 1;
            cbo_Nam.SelectedItem = currentYear;
        }

        private void ThongKe2()
        {
            if (cbo_Thang.SelectedItem != null && cbo_Nam.SelectedItem != null)
            {
                int selectedMonth = int.Parse(cbo_Thang.SelectedItem.ToString());

                if (cbo_Nam.SelectedItem != null)
                {
                    int selectedYear = int.Parse(cbo_Nam.SelectedItem.ToString());

                    string query = "EXEC Tongdoanhthutheothang @Thang = " + selectedMonth + ", @Nam = " + selectedYear;
                    DataTable dataTable = db.getDaTaTable(query);

                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Hãy chọn tháng năm thực thi.");
                }
            }
        }

        private void TongDoanhThuNam()
        {
                if (cbo_Nam.SelectedItem != null)
                {
                    int selectedYear = int.Parse(cbo_Nam.SelectedItem.ToString());

                    string query = "EXEC TongDoanhThuTrongNam @Nam = " + selectedYear;
                    DataTable dataTable = db.getDaTaTable(query);

                    dataGridView4.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Hãy chọn năm thực thi.");
                }
        }

        private void cbo_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe2();
            Top5DonHangCaoNhat();
            TongLuongNhapKhoTrongNam();
        }

        private void cbo_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            TongDoanhThuNam();
            TongLuongNhapKhoTrongNam();
        }

        private void ThongKeTrangThaiDonHang()
        {
            string query = "EXEC ThongKeTrangThaiDonHang";
            DataTable dt = db.getDaTaTable(query);
            dataGridView2.DataSource = dt;
        }

        private void Top5DonHangCaoNhat()
        {
            if (cbo_Thang.SelectedItem != null && cbo_Nam.SelectedItem != null)
            {
                int selectedMonth = int.Parse(cbo_Thang.SelectedItem.ToString());

                if (cbo_Nam.SelectedItem != null)
                {
                    int selectedYear = int.Parse(cbo_Nam.SelectedItem.ToString());

                    string query = "EXEC top5donhangcaonhat2 @Thang = " + selectedMonth + ", @Nam = " + selectedYear;
                    DataTable dataTable = db.getDaTaTable(query);

                    dataGridView3.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Hãy chọn tháng năm thực thi.");
                }
            }
        }

        private void TongLuongNhapKhoTrongNam()
        {
            if (cbo_Thang.SelectedItem != null && cbo_Nam.SelectedItem != null && cbo_makho.SelectedItem != null)
            {
                int selectedMonth = int.Parse(cbo_Thang.SelectedItem.ToString());

                if (cbo_Nam.SelectedItem != null)
                {
                    int selectedYear = int.Parse(cbo_Nam.SelectedItem.ToString());

                    if (cbo_makho.SelectedItem != null)
                    {
                        //int selectedMaKho = int.TryParse(ReadOnlySpan<cbo_makho.SelectedItem> s, out int newint);

                    string query = "EXEC ThongKeNhapKhoTrongNam @MaKho = " + cbo_makho.SelectedValue + ", @Thang = " + selectedMonth + ", @Nam = " + selectedYear;
                    //string query = "EXEC ThongKeNhapKhoTrongNam @Thang = " + selectedMonth + ", @Nam = " + selectedYear;
                    DataTable dataTable = db.getDaTaTable(query);

                    dataGridView5.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn mã kho và tháng năm thực thi.");
                }
            }
        }

        private void hienThiDSMaKho_cbo()
        {
            string query = "Select * from KHO";
            DataTable dt = db.getDaTaTable(query);
            cbo_makho.DataSource = dt;
            cbo_makho.DisplayMember = "MAKHO";
            cbo_makho.ValueMember = "MAKHO";
        }

        private void cbo_makho_SelectedIndexChanged(object sender, EventArgs e)
        {
            TongLuongNhapKhoTrongNam();
        }

    }
}

