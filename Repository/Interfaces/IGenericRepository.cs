using System.Linq.Expressions;

namespace DigitalExaminationSys.Repository.Interfaces
{
    public interface IGenericRepository<T,Y> where T : class , IBaseModel<Y>
    {
        T GetById(Y id);
        IQueryable<T> GetAll();
        IQueryable<T> GetByExpressions(Expression<Func<T,bool>> expression);
        T Insert(T entity);
        void Update(T entity);
        void Delete(Y id);

    }
}
