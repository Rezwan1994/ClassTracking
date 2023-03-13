using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Interface;
using ClassTracking.Repository.Interface.ClassTracking;
using ClassTracking.Repository.UnitOfWork;
using ClassTracking.Service.Interface.ClassTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Service.Implementation.ClassTracking
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IStudentRepository _studentExtRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentExtRepository)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = unitOfWork.Repository<Student>();
            _studentExtRepository = studentExtRepository;
        }
        public List<Student> GetAllStudentByClassId(Guid classId)
        {
            return _studentExtRepository.GetAllStudentByClassId(classId);
        }
    }
}
