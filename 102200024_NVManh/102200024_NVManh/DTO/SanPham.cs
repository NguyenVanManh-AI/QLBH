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
    public class SanPham
    {
        [Key]
        [Required]
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public float giaNhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayNhap { get; set; }
        public int soLuongSP { get; set; }
        public int maNCC { get; set; }

        public bool tinhTrang { get; set; }

        [ForeignKey("maNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }
        // mỗi sản phẩm chỉ thuộc một nhà cung cấp 
        // một nhà cung cấp có nhiều sản phẩm 

    }
}
