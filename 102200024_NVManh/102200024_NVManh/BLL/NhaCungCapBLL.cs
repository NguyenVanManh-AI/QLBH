using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _102200024_NVManh.DTO;//+
using _102200024_NVManh.DAL;//+

namespace _102200024_NVManh.BLL
{
    public class NhaCungCapBLL
    {
        QLBH db;
        private static NhaCungCapBLL _Instance;
        public static NhaCungCapBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new NhaCungCapBLL();
                return _Instance;
            }
            set { }
        }
        public NhaCungCapBLL()
        {
            db = new QLBH();
        }
        public List<string> GetAllTenNCC()
        {
            return db.NhaCungCaps.Select(x => x.tenNCC).ToList();
        }
        public List<string> GetAllTenNCCbyTP(string tenTP)
        {
            string maTP = db.DiaChis.Where(x=>x.tenTP == tenTP).Select(x => x.maTP).First();
            return db.NhaCungCaps.Where(x=>x.maTP == maTP).Select(x => x.tenNCC).ToList();
        }

    }
}
