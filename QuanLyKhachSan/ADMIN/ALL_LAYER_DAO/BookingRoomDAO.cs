using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.ADMIN.ALL_LAYER_DAO
{
    internal class BookingRoomDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();
        public int demDatPhong()
        {
            var q = from k in db.DatPhongs select k;
            return q.Count() + 1;
        }
        public string checkMaKhachHang(string a)
        {
            string kq = "";
            var q = from k in db.KhachHangs where k.MaKH.ToString() == a select k;
            foreach (var k in q)
            {
                kq = k.HoTen.ToString();
            }
            return kq;
        }
        public bool checkSoNguoi(string sl,string ma)
        {
            bool kq = false;
            var q = from k in db.Phongs
                    join j in db.LoaiPhongs on k.LoaiPhong equals j.MaLoaiPhong
                    where ma == k.MaPhong.ToString()
                    select new
                    {
                        k,
                        j
                    };
            foreach(var i in q)
            {
                if (i.j.SoNguoi <= Convert.ToInt32(sl))
                {
                    kq = true;
                }
            }
            return kq;
        }
        public void Them(DatPhong f)
        {
            db.DatPhongs.Add(f);
            db.SaveChanges();
            MessageBox.Show("Đặt phòng thành công!");
        }
    }
}
