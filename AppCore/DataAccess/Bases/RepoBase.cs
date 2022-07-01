using AppCore.Records.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.DataAccess.Bases
{
    public abstract class RepoBase<T> : IDisposable where T : KayitBase, new()
    {
        const string _kaydedilmedi = "Değişiklikler kaydedilmedi!";
        const string _kaydedildi = "Değişiklikler kaydedildi.";

        private readonly string _isDeletedEntityProperty;

        private readonly DbContext _db;

        protected RepoBase(DbContext db)
        {
            _db = db;
            _isDeletedEntityProperty = typeof(IKayitSoftDelete).GetProperties().FirstOrDefault().Name; // IsDeleted
            if (typeof(T).GetProperty(_isDeletedEntityProperty) == null)
            {
                _isDeletedEntityProperty = null;
            }
        }

        public virtual IQueryable<T> Query()
        {
            var query = _db.Set<T>().AsQueryable();
            if (_isDeletedEntityProperty != null)
                query = query.Where(e => EF.Property<bool>(e, _isDeletedEntityProperty) == false);
            return query;
        }

        public virtual List<T> GetList()
        {
            return Query().ToList();
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return Query().Where(predicate).ToList();
        }

        public virtual T GetItem(int id)
        {
            return Query().SingleOrDefault(e => e.Id == id);
        }

        public virtual Result Add(T entity, bool save = true)
        {
            entity.Guid = Guid.NewGuid();
            _db.Set<T>().Add(entity);
            if (save)
            {
                Save();
                return new SuccessResult(_kaydedildi);
            }
            return new ErrorResult(_kaydedilmedi);
        }

        public virtual Result Update(T entity, bool save = true)
        {
            _db.Set<T>().Update(entity);
            if (save)
            {
                Save();
                return new SuccessResult(_kaydedildi);
            }
            return new ErrorResult(_kaydedilmedi);
        }

        public virtual Result Delete(T entity, bool save = true)
        {
            _db.Set<T>().Remove(entity);
            if (save)
            {
                Save();
                return new SuccessResult(_kaydedildi);
            }
            return new ErrorResult(_kaydedilmedi);
        }

        public virtual Result Delete(Expression<Func<T, bool>> predicate, bool save = true)
        {
            var list = Query().Where(predicate).ToList();
            foreach (var item in list)
            {
                Delete(item, false);
            }
            if (save)
            {
                Save();
                return new SuccessResult(_kaydedildi);
            }
            return new ErrorResult(_kaydedilmedi);
        }

        public virtual int Save()
        {
            try
            {
                if (_isDeletedEntityProperty != null)
                {
                    foreach (var entry in _db.ChangeTracker.Entries<T>())
                    {
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                entry.CurrentValues[_isDeletedEntityProperty] = false;
                                break;
                            case EntityState.Deleted:
                                entry.CurrentValues[_isDeletedEntityProperty] = true;
                                entry.State = EntityState.Modified;
                                break;
                        }
                    }
                }
                return _db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
