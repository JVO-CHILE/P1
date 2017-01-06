using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        Task<TEntity> FindAsync(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        Task Delete(params object[] id);

        IQueryable<TEntity> Queryable();
    }
}