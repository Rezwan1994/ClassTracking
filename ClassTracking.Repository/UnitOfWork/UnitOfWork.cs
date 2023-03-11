using ClassTracking.Domain.DbContexts;
using ClassTracking.Repository.Implementation;
using ClassTracking.Repository.Implementation.ClassTracking;
using ClassTracking.Repository.Interface;
using ClassTracking.Repository.Interface.ClassTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ClassTrackingDbContext _dbContext;
        private bool _disposed;
        private readonly Hashtable _repositories;
        private IStudentRepository _studentRepository;

        public UnitOfWork(ClassTrackingDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }
        public virtual Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                _repositories.Add(type, new Repository<TEntity>(_dbContext));
            }
            return (IRepository<TEntity>)_repositories[type];
        }
        public IStudentRepository IStudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(_dbContext);
                }
                return _studentRepository;
            }
        }
        public void Dispose()
        {
          
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
