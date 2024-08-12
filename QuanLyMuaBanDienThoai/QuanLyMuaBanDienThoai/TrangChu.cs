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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            Customize();
        }
        private void Customize()
        {
            panelsubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelsubmenu.Visible == true)
                panelsubmenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPham());
        }

        private void btn_Kho_Click(object sender, EventArgs e)
        {
            showSubMenu(panelsubmenu);
            OpenChildForm(new Kho());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }


        private void btn_NhapKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhapKho());
            hideSubMenu();
        }

        private void btn_XuatKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XuatKho());
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
        }

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCungCap());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyKhachHang());
        }

        private void btn_DonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DonHang());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyNhanVien());
        }

        

    }
}
