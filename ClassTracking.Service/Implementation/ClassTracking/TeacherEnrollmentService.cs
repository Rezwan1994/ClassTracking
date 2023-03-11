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
    public class TeacherEnrollmentService : BaseService<TeacherEnrollment>, ITeacherEnrollmentService
    {
        private readonly IRepository<TeacherEnrollment> _teacherEnrollmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TeacherEnrollmentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherEnrollmentRepository = unitOfWork.Repository<TeacherEnrollment>();
        }
    }
}
