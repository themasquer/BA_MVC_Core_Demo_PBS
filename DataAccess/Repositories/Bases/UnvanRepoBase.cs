using AppCore.DataAccess.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Bases
{
    public abstract class UnvanRepoBase : RepoBase<Unvan>
    {
        protected UnvanRepoBase(DbContext db) : base(db)
        {
        }
    }
}
