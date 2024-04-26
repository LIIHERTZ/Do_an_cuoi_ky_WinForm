using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.ADMIN.ALL_LAYER_DAO
{
    internal class ServiceDAO
    {
        QLKS_ENTITY db = new QLKS_ENTITY();
        public void SaveImage(PictureBox image, out string filename)
        {
            filename = string.Empty;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                image.Image = Image.FromFile(opf.FileName);
                filename = Path.GetFileName(opf.FileName);
                string appDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string dest = Path.Combine(appDirectory, filename);
                File.Copy(opf.FileName, dest, true);
            }
        }

        public void Them(DichVu f)
        {
            db.DichVus.Add(f);
            db.SaveChanges();
            MessageBox.Show("Thêm dịch vụ thành công!");
        }

        public void Xoa(string madv)
        {
            var d = db.DichVus.FirstOrDefault(k => k.MaDV == madv);
            if (d != null)
            {
                db.DichVus.Remove(d);
                db.SaveChanges();
            }
            MessageBox.Show("Xoá thông tin dịch vụ thành công!");
        }

        public void Sua(DichVu a)
        {
            var p = db.DichVus.FirstOrDefault(k => k.MaDV == a.MaDV);
            if (p != null)
            {
                p.MaDV = a.MaDV;
                p.TenDV = a.TenDV;
                p.Gia = a.Gia;
                p.Anh = a.Anh;

                db.SaveChanges();
            }
            MessageBox.Show("Sửa thông tin dịch vụ thành công!");
        }
        public List<DichVu> LoadDV()
        {
            var p = from DichVu v in db.DichVus select v;
            return p.ToList();
        }

        public bool check(string a)
        {
            var p = from k in db.DichVus where k.MaDV == a select k;
            if (p.Any()) return false;
            return true;
        }

        public DataTable ConvertListToDataTable(List<DichVu> list)
        {
            DataTable table = new DataTable();

            // Tạo các cột cho DataTable dựa trên các thuộc tính của đối tượng DichVu
            foreach (var p in typeof(DichVu).GetProperties())
            {
                table.Columns.Add(p.Name, p.PropertyType);
            }

            // Thêm dữ liệu từ danh sách vào DataTable
            foreach (var item in list)
            {
                DataRow row = table.NewRow();
                foreach (var p in typeof(DichVu).GetProperties())
                {
                    row[p.Name] = p.GetValue(item);
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
