using DataAccess.Contexts;
using DataAccess.Repositories.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UnvanRepo : UnvanRepoBase
    {
        public UnvanRepo(Db db) : base(db)
        {
        }
    }
}
