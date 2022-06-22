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
    public class DiaChi
    {
        public DiaChi()
        {
            this.NhaCungCaps = new HashSet<NhaCungCap>();
        }
        [Key]
        [Required]
        public string maTP { get; set; }
        public string tenTP { get; set; }
        public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; }
    }
}
