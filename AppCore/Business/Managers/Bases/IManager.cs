using AppCore.Records.Bases;
using AppCore.Results.Bases;

namespace AppCore.Business.Managers.Bases
{
    public interface IManager<TModel, TEntity> : IDisposable where TModel : class, new() where TEntity: class, new()
    {
        IQueryable<TModel> Query();
        Result Add(TModel model);
        Result Update(TModel model);
        Result Delete(int id);
    }
}
