using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _102200024_NVManh.DTO;//+

namespace _102200024_NVManh.DAL
{
    public class CreateDB :
        CreateDatabaseIfNotExists<QLBH>
    {
        protected override void Seed(QLBH dbo)
        {
            dbo.DiaChis.AddRange(new DiaChi[]
            {
                new  DiaChi {maTP="33", tenTP="Hà Nội"},
                new  DiaChi {maTP="41", tenTP="Hồ Chí Minh"}
            });
            dbo.NhaCungCaps.AddRange(new NhaCungCap[]
            {
                new NhaCungCap {maNCC=1, tenNCC="Caro", maTP="41"},
                new NhaCungCap {maNCC=2, tenNCC="FPT", maTP="33"},

            });
            dbo.SanPhams.AddRange(new SanPham[]
            {
                new SanPham {maSP="Banh01", tenSP="Bánh Richy", giaNhap= 3000, ngayNhap= new DateTime(2022,6,21), soLuongSP= 10, tinhTrang=true, maNCC= 1},
                new SanPham {maSP="LapTop01", tenSP="Máy tính sách tay", giaNhap= 2000, ngayNhap= new DateTime(2021,12,21), soLuongSP= 100, tinhTrang=false, maNCC= 2},
            });

        }
    }



}
