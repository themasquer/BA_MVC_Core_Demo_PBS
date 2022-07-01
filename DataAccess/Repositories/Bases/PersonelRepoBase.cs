using AppCore.DataAccess.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Bases
{
    public abstract class PersonelRepoBase : RepoBase<Personel>
    {
        protected PersonelRepoBase(DbContext db) : base(db)
        {
        }
    }
}
