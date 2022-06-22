using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations; //+   // add Refrencse 
using System.ComponentModel.DataAnnotations.Schema; //+
using static System.Net.Mime.MediaTypeNames; //+

namespace _102200024_NVManh.DTO
{
    public class SanPhamView
    {
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public float giaNhap { get; set; }

        public int soLuongSP { get; set; }
        public DateTime ngayNhap { get; set; }

        public bool tinhTrang { get; set; }

        public string tenNCC { get; set; }

        public string tenTP { get; set; }
    }
}
