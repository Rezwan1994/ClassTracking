using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Interface;
using ClassTracking.Repository.UnitOfWork;
using ClassTracking.Service.Interface.ClassTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Service.Implementation.ClassTracking
{
    public class ClassService : BaseService<Class>, IClassService
    {
        private readonly IRepository<Class> _classRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _classRepository = unitOfWork.Repository<Class>();
        }
    }
}
