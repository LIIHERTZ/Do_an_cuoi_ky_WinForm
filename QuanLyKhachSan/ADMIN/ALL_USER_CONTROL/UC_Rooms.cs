using QuanLyKhachSan.ADMIN.ALL_FORM;
using QuanLyKhachSan.ADMIN.ALL_LAYER_DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.ADMIN.ALL_USER_CONTROL
{
    public partial class UC_Rooms : UserControl
    {
        public UC_Rooms()
        {
            InitializeComponent();
        }
        UC_RoomsDAO ucroomsdao = new UC_RoomsDAO();
        AdminDAO admindao = new AdminDAO();
        string appDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public UC_Rooms(Phong a, LoaiPhong b)
        {
            InitializeComponent();
            lbl_GiaTien.Text = b.Gia.ToString();
            lbl_TinhTrang.Text = a.TinhTrang;
            lbl_MaLoaiPhong.Text = a.MaPhong.ToString();
            lbl_LoaiPhong.Text = b.MaLoaiPhong;
            lbl_SoNguoi.Text = b.SoNguoi.ToString();
            lbl_MoTa.Text = b.MoTa.ToString();
            string image1 = Path.Combine(appDirectory, b.Anh);
            pic_Anh.Image = Image.FromFile(image1);
            if (lbl_TinhTrang.Text.Contains("full"))
            {
                pn_TinhTrang.BackColor = Color.Red;
                btn_DatPhong.Enabled = false;
            }
        }

        private void btn_DatPhong_Click(object sender, EventArgs e)
        {
            BookingRoom a = new BookingRoom (lbl_GiaTien.Text, lbl_MaLoaiPhong.Text);
            a.ShowDialog();
        }
    }
}
