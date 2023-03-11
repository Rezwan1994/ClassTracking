using ClassTracking.Repository.Interface;
using ClassTracking.Repository.Interface.ClassTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IStudentRepository IStudentRepository { get; }
   
    }
}
