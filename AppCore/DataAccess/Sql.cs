using Microsoft.EntityFrameworkCore;

namespace AppCore.DataAccess
{
    public class Sql<T> : IDisposable where T : DbContext, new()
    {
        private readonly DbContext _db;

        public Sql(DbContext db)
        {
            _db = db;
        }

        public virtual int ExecuteSql(string sql) // exec p_personelEkle @
        {
            return _db.Database.ExecuteSqlRaw(sql);
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
