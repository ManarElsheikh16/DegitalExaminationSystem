using DigitalExaminationSys.Models;
using DigitalExaminationSys.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigitalExaminationSys.Repository
{
    public class GenericRepository<T, Y> : IGenericRepository<T, Y> where T : class, IBaseModel<Y>
    {
        Context _Context { get; set; }

        public GenericRepository(Context context)
        {
            _Context = context;
        }

       public void Delete(Y id)
        {
            T Entity = GetById(id);
            Entity.IsDeleted= true;
            Update(Entity);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable < T > Entities= _Context.Set<T>();
            return Entities;
        }

        public IQueryable<T> GetByExpressions(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> Entities = _Context.Set<T>().Where(expression);
            return Entities;
        }

        public T GetById(Y id)
        {
            T Entity=_Context.Set<T>().FirstOrDefault(X => X.Id.Equals(id));
            return Entity;
        }

        public T Insert(T entity)
        {
           _Context.Set<T>().Add(entity);
           
           return entity;
        }

        public void Update(T entity)
        {
            _Context.Update(entity);
        }
    }
}
