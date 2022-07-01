using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Unvan> Unvanlar { get; set; }

        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
    }
}
