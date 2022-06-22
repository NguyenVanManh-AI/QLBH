using System;
using System.Data.Entity;
using System.Linq;

using _102200024_NVManh.DTO; //+ 

namespace _102200024_NVManh.DAL
{
    public class QLBH : DbContext
    {
        // Your context has been configured to use a 'QLBH' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_102200024_NVManh.DAL.QLBH' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLBH' 
        // connection string in the application configuration file.
        public QLBH()
            : base("name=QLBH")
        {
            Database.SetInitializer<QLBH>(new CreateDB());
        }

        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}