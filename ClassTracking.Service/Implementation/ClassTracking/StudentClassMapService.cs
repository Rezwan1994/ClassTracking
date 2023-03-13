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
    public class StudentClassMapService : BaseService<StudentClassMap>, IStudentClassMapService
    {
        private readonly IRepository<StudentClassMap> _studentClasslassRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudentClassMapService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _studentClasslassRepository = unitOfWork.Repository<StudentClassMap>();
        }
    }
}
