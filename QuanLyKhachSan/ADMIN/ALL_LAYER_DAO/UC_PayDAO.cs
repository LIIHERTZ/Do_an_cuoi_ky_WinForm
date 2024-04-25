using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ADMIN.ALL_LAYER_DAO
{
    internal class UC_PayDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();
        public List<HoaDon> loadHoaDon()
        {
            var p = from k in db.HoaDons where k.TinhTrang == "wait" select k;
            return p.ToList();
        }
    }
}
