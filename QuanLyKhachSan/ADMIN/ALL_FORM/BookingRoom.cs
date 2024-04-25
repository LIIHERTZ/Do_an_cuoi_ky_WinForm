using QuanLyKhachSan.ADMIN.ALL_LAYER_DAO;
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
    public partial class BookingRoom : Form
    {
        BookingRoomDAO booking =new BookingRoomDAO();
        public BookingRoom()
        {
            InitializeComponent();
        }
        public BookingRoom(string a, string b)
        {
            InitializeComponent();
            booking = new BookingRoomDAO();
            int sl =  booking.demDatPhong();
            txt_MaDatPhong.Text = sl.ToString();

            txt_MaDatPhong.Enabled = false;
            txt_MaPhong.Enabled = false;

            txt_GiaTien.Text = a;
            txt_GiaTien.Enabled = false;

            txt_MaPhong.Text = b;
            txt_MaPhong.Enabled = false ;

            DateTime currentTime = DateTime.Now;
            TimeSpan timeOfDay = currentTime.TimeOfDay;
            string formattedTime = $"{timeOfDay.Hours:D2}:{timeOfDay.Minutes:D2}:{timeOfDay.Seconds:D2}";
            txt_ThoiGian.Text = formattedTime;
            txt_ThoiGian.Enabled = false;

            DateTime currentDate = DateTime.Today;
            string dateString = currentDate.ToString("yyyy-MM-dd");
            txt_NgayDat.Text = dateString;
            txt_NgayDat.Enabled = false;
                
            txt_TenKhachHang.Enabled = false;
        }

        private void btn_Thoat_DashBoard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            booking = new BookingRoomDAO();
            DatPhong a = new DatPhong();
            a.MaKH = Convert.ToInt32(txt_MaKH.Text);
            a.MaPhong = Convert.ToInt32(txt_MaPhong.Text);

            DateTime currentDate = DateTime.Now;
            a.NgayDat = currentDate;
            a.ThoiGianDat = currentDate;

            if (txt_SoNguoi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn số lượng người!", "Chú ý");
            }
            else if (booking.checkSoNguoi(txt_SoNguoi.Text,txt_MaPhong.Text))
            {
                MessageBox.Show("Vượt quá lượng người cho phép!", "Chú ý");
            }
            else
            {
                booking.Them(a);
                UC_RoomsDAO ucroom = new UC_RoomsDAO();
                ucroom.Sua(txt_MaPhong.Text);
                this.Close();
            }
        }

        private void txt_MaKH_TextChanged(object sender, EventArgs e)
        {
            booking = new BookingRoomDAO();
            string s = booking.checkMaKhachHang(txt_MaKH.Text);
            txt_TenKhachHang.Text = s;

        }
    }
}
