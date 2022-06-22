using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _102200024_NVManh.DTO;//+
using _102200024_NVManh.DAL;//+

namespace _102200024_NVManh.BLL
{
    public class SanPhamBLL
    {
        QLBH db;
        private static SanPhamBLL _Instance;
        public static SanPhamBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new SanPhamBLL();
                return _Instance;
            }
            set { }
        }
        public SanPhamBLL()
        {
            db = new QLBH();
        }

        // load dữ liệu ra ngoài 
        public List<SanPham> GetAllSanPham()
        {
            return db.SanPhams.ToList();
        }

        public SanPhamView GetSPViewBySP(SanPham x)
        {
            return new SanPhamView
            {
                maSP = x.maSP,
                giaNhap = x.giaNhap,
                tenSP = x.tenSP,
                soLuongSP = x.soLuongSP,
                tinhTrang = x.tinhTrang,
                ngayNhap = x.ngayNhap,
                tenNCC = x.NhaCungCap.tenNCC,
                tenTP = x.NhaCungCap.DiaChi.tenTP
            };
        }

        public List<SanPhamView> GetAllSanPhamView()
        {
            List<SanPhamView> data = new List<SanPhamView>();
            foreach (SanPham x in GetAllSanPham())
            {
                data.Add(GetSPViewBySP(x));
            }
            return data;

        }

        // tìm kiếm 
        public List<SanPham> SearchAllSanPham(string tenNCC, string text)
        {
            return db.NhaCungCaps.Where(x => x.tenNCC.Contains(tenNCC)).First().SanPhams.Where(y => y.tenSP.Contains(text) 
            || y.soLuongSP.ToString().Contains(text) || y.ngayNhap.ToString().Contains(text) 
            || y.tinhTrang.ToString().Contains(text) || y.maNCC.ToString().Contains(text)).ToList();
        }
        public List<SanPhamView> SearchSanPhamView(string _tenNCC, string _text)
        {
            List<SanPhamView> data = new List<SanPhamView>();
            foreach (SanPham x in SearchAllSanPham(_tenNCC,_text))
            {
                data.Add(GetSPViewBySP(x));
            }
            return data;
        }

        // thêm 

        public void AddSanPham(SanPham x)
        {
            db.SanPhams.Add(x);
            db.SaveChanges();
        }

        // sửa 
        public void EditSanPham(SanPham y)
        {
            var x = db.SanPhams.Find(y.maSP);
            x.tenSP = y.tenSP;
            x.tinhTrang = y.tinhTrang;
            x.maNCC = y.maNCC;
            x.ngayNhap = y.ngayNhap;

            db.SaveChanges();
        }

        public int getMaNCCbyName(string nameNCC)
        {
            return db.NhaCungCaps.Where(x => x.tenNCC == nameNCC).Select(x => x.maNCC).First();
        }

        // xóa 
        public void DeleteSanPham(string maSP)
        {
            db.SanPhams.Remove(db.SanPhams.Find(maSP));
            db.SaveChanges();
        }

        // sắp xếp 
        public List<SanPhamView> SortAllSanPhamView(string sort)
        {
            List<SanPhamView> data = new List<SanPhamView>();
            foreach (SanPham x in GetAllSanPham())
            {
                data.Add(GetSPViewBySP(x));
            }
            if (sort == "Tên sản phẩm") data = data.OrderBy(x => x.tenSP).ToList();
            if (sort == "Tên thành phố") data = data.OrderBy(x => x.tenTP).ToList();
            if (sort == "Tên nhà cung cấp") data = data.OrderBy(x => x.tenNCC).ToList();
            if (sort == "Ngày nhập") data = data.OrderBy(x => x.ngayNhap).ToList();
            if (sort == "Giá nhập") data = data.OrderBy(x => x.giaNhap).ToList();
            if (sort == "Tình trạng") data = data.OrderBy(x => x.tinhTrang).ToList();
            return data;
        }


    }
}
