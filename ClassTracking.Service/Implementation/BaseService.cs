using ClassTracking.Repository.Interface;
using ClassTracking.Repository.UnitOfWork;
using ClassTracking.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Service.Implementation
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<TEntity>();
        }
        public async Task DeleteAsync(int id)
        {
            _repository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public  IQueryable<TEntity> Get()
        {
            return _repository.Get();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _repository.Get().ToListAsync();
        }

     

        public async Task InsertAsync(TEntity entity, bool save = true)
        {
            _repository.Add(entity);
            if (save)
            {
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity, bool save = true)
        {
            _repository.Edit(entity);
            if (save)
            {
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
