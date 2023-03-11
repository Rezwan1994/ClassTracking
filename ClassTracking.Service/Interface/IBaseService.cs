using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Service.Interface
{
    public interface IBaseService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();
        IQueryable<TEntity> Get();
        Task<TEntity> FindAsync(int id);
        Task InsertAsync(TEntity entity, bool save = true);
        Task UpdateAsync(TEntity entity, bool save = true);
        Task DeleteAsync(int id);
        Task DeleteAsync(TEntity entity);

    }
}
