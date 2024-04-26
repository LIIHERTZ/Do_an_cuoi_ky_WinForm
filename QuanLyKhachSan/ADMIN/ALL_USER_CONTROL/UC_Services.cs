using QuanLyKhachSan.ADMIN.ALL_FORM;
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
    public partial class UC_Services : UserControl
    {
        public UC_Services()
        {
            InitializeComponent();
        }

        string appDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public UC_Services(DichVu f)
        {
            InitializeComponent();
            lbl_MaDV.Text = f.MaDV;
            lbl_TenDV.Text = f.TenDV;
            lbl_GiaTien.Text = f.Gia.ToString();
            string image1 = Path.Combine(appDirectory, f.Anh);
            pic_AnhDichVu.Image = Image.FromFile(image1);
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            Service a = new Service();
            a.ShowDialog();
        }
    }
}
