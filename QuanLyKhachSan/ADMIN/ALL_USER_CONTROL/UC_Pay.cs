using QuanLyKhachSan.ADMIN.ALL_LAYER_DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace QuanLyKhachSan.ADMIN.ALL_USER_CONTROL
{
    public partial class UC_Pay : UserControl
    {
        UC_PayDAO payDAO = new UC_PayDAO();
        QLKS_ENTITY db = new QLKS_ENTITY();
        public UC_Pay()
        {
            InitializeComponent();
            cb_TimKiem.DataSource = payDAO.loadHoaDon();
            cb_TimKiem.DisplayMember = "MaHoaDon";
            cb_TimKiem.ValueMember = "MaHoaDon";
            cb_TimKiem.SelectedIndex = -1;
        }

        private void btn_KiemTra_Click(object sender, EventArgs e)
        {
            if (cb_TimKiem.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn mã thanh toán?", "Chú ý!");
            }
            else
            {
                var query = from hoaDon in db.HoaDons
                            join nhanVien in db.NhanViens on hoaDon.NhanVienThanhToan equals nhanVien.MaNV
                            join datPhong in db.DatPhongs on hoaDon.MaDatPhong equals datPhong.MaDatPhong
                            join phong in db.Phongs on datPhong.MaPhong equals phong.MaPhong
                            join loaiPhong in db.LoaiPhongs on phong.LoaiPhong equals loaiPhong.MaLoaiPhong
                            join khachHang in db.KhachHangs on datPhong.MaKH equals khachHang.MaKH
                            where hoaDon.MaHoaDon.ToString() == cb_TimKiem.SelectedValue.ToString()
                            select new
                            {
                                HoaDon = hoaDon,
                                NhanVien = nhanVien,
                                DatPhong = datPhong,
                                Phong = phong,
                                LoaiPhong = loaiPhong,
                                KhachHang = khachHang
                            };
                foreach(var item in query)
                {
                    lbl_MaHD.Text = item.HoaDon.MaHoaDon.ToString();
                    lbl_MaDatPhong.Text = item.DatPhong.MaDatPhong.ToString();
                    lbl_MaKH.Text = item.KhachHang.MaKH.ToString();
                    lbl_MaPhong.Text = item.Phong.MaPhong.ToString();   
                    lbl_LoaiPhong.Text = item.LoaiPhong.MaLoaiPhong;
                    lbl_NgayDatPhong.Text = item.DatPhong.NgayDat.ToString();
                    string ngayTra = item.HoaDon.NgayLap.ToString();
                    lbl_NgayTraPhong.Text = item.HoaDon.NgayLap.ToString();
                    lbl_NgayLapHoaDon.Text = ngayTra.Substring(0, 10);
                    lbl_MaNV.Text = item.NhanVien.HoTen.ToString();
                    lbl_TenKH.Text = item.KhachHang.HoTen.ToString();
                    lbl_TienPhong.Text = item.LoaiPhong.Gia.ToString() + " vnđ/ngày";
                }
            }
        }
    }
}
