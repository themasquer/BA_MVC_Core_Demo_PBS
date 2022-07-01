using DataAccess.Contexts;
using DataAccess.Repositories.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PersonelRepo : PersonelRepoBase
    {
        public PersonelRepo(Db db) : base(db)
        {
        }
    }
}
