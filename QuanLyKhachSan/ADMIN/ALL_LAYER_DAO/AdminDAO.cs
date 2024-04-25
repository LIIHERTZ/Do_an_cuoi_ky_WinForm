using QuanLyKhachSan.ADMIN.ALL_USER_CONTROL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.ADMIN.ALL_LAYER_DAO
{
    internal class AdminDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();
        public void loadAllUCRooms(FlowLayoutPanel f)
        {
            var q = from k in db.Phongs
                    join j in db.LoaiPhongs on k.LoaiPhong equals j.MaLoaiPhong
                    select new
                    {
                        k,
                        j
                    };
            foreach (var item in q)
            {
                Phong a = new Phong();
                LoaiPhong b = new LoaiPhong();
                a.MaPhong = item.k.MaPhong;
                a.LoaiPhong = item.k.LoaiPhong;
                a.TinhTrang = item.k.TinhTrang;
                b.MaLoaiPhong = item.j.MaLoaiPhong;
                b.MoTa = item.j.MoTa;
                b.Gia = item.j.Gia;
                b.Anh = item.j.Anh;
                b.SoNguoi = item.j.SoNguoi;
                UC_Rooms c = new UC_Rooms(a,b);
                f.Controls.Add(c);
            }
        }
    }
}
