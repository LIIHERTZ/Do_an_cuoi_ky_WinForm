using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ADMIN.ALL_LAYER_DAO
{
    internal class UC_BookedRoomsDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();
        public string layTenKhachHang(string a)
        {
            string b = "";
            var q = from k in db.KhachHangs where k.MaKH.ToString() == a select k;
            foreach (var k in q)
            {
                b = k.HoTen;
            }
            return b;
        }
    }
}
