using QuanLyKhachSan.ADMIN.ALL_LAYER_DAO;
using QuanLyKhachSan.ADMIN.ALL_USER_CONTROL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.ADMIN.ALL_FORM
{
    public partial class Admin : Form
    {
        AdminDAO admin = new AdminDAO();
        string tendnNV;
        public Admin()
        {
            InitializeComponent();
        }
        public Admin(string s)
        {
            InitializeComponent();
            tendnNV = s;

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = (MessageBox.Show("Bạn có muốn thoát không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (traloi == DialogResult.Yes) Application.Exit();
        }

        private void btn_XemPhong_Click(object sender, EventArgs e)
        {
            pn_HienThi.Controls.Clear();
            admin = new AdminDAO();
            admin.loadAllUCRooms(pn_HienThi);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            pn_HienThi.Controls.Clear();
        }

        private void btn_XemPhongDat_Click(object sender, EventArgs e)
        {
            pn_HienThi.Controls.Clear();
            admin = new AdminDAO();
            admin.loadAllUCBookedRooms(pn_HienThi,tendnNV);
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            pn_HienThi.Controls.Clear();
            admin = new AdminDAO();
            admin.loadThanhToan(pn_HienThi);
        }

        private void btn_CheckIn_Click(object sender, EventArgs e)
        {
            pn_HienThi.Controls.Clear();
            admin = new AdminDAO();
            admin.loadAllUCReserveRooms(pn_HienThi, tendnNV);
        }

    }
}
