using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _102200024_NVManh.DTO;//+
using _102200024_NVManh.DAL;//+

namespace _102200024_NVManh.BLL
{
    public class DiaChiBLL
    {
        QLBH db;
        private static DiaChiBLL _Instance;
        public static DiaChiBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new DiaChiBLL();
                return _Instance;
            }
            set { }
        }
        public DiaChiBLL()
        {
            db = new QLBH();
        }

        public List<string> GetAllTenTP()
        {
            return db.DiaChis.Select(x => x.tenTP).ToList();
        }
    }
}
