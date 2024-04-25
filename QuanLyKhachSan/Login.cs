using QuanLyKhachSan.ADMIN.ALL_FORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class Login : Form
    {
        string chucvu;
        LoginDAO login = new LoginDAO();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            DangNhap a = new DangNhap();
            a.TenDangNhap = txt_TenDangNhap.Text;
            a.MatKhau = txt_MatKhau.Text;
            a.ChucVu = chucvu;
            if (login.check(a) == true)
            {
                this.Hide();
                Admin dashboard = new Admin(txt_TenDangNhap.Text);
                dashboard.ShowDialog();
            }
            else
            {
                if (txt_TenDangNhap.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tài khoản!");
                    txt_TenDangNhap.Focus();
                }
                else if (txt_MatKhau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu!");
                    txt_MatKhau.Focus();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập chưa chính xác!");
                    txt_TenDangNhap.Focus();
                }


            }
        }

        private void pic_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = (MessageBox.Show("Bạn có muốn thoát không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (traloi == DialogResult.Yes) Application.Exit();
        }

        private void chb_NhanVien_CheckedChanged(object sender, EventArgs e)
        {
            chucvu = "nv";
        }

        private void chb_KhachHang_CheckedChanged(object sender, EventArgs e)
        {
            chucvu = "kh";
        }
    }
}
