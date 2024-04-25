using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    internal class LoginDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();

        public bool check(DangNhap f)
        {

            var p = from k in db.DangNhaps where k.TenDangNhap == f.TenDangNhap && k.MatKhau == f.MatKhau && k.ChucVu == f.ChucVu select k;
            return p.Any();

        }
    }
}
