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
    public class NhaCungCap
    {
        // sản phẩm liên kết đến nhà cung cấp thì nhà cung cấp cũng phải trỏ đến lại 
        public NhaCungCap()
        {
            this.SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Required]
        public int maNCC { get; set; }
        public string tenNCC { get; set; }
        public string maTP { get; set; }

        [ForeignKey("maTP")]
        public virtual DiaChi DiaChi { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
        // tương tự mỗi nhà cung cấp chỉ thuộc một tỉnh 
        // một tỉnh có nhiều nhà cung cấp 

    }
}
