using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ADMIN.ALL_LAYER_DAO
{
    internal class UC_RoomsDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();


        public void Sua(string MaPhong)
        {
            var p = from k in db.Phongs where k.MaPhong.ToString() == MaPhong select k;
            if (p.Any())
            {
                foreach (var j in p)
                {
                    j.TinhTrang = "full";
                }
                db.SaveChanges();
            }
        }
    }
}
