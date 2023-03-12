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
    public class TeacherEnrollmentService : BaseService<TeacherEnrollment>, ITeacherEnrollmentService
    {
        private readonly IRepository<TeacherEnrollment> _teacherEnrollmentRepository;
        private readonly ITeacherEnrollmentRepository _enrollmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TeacherEnrollmentService(IUnitOfWork unitOfWork, ITeacherEnrollmentRepository enrollmentRepository)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherEnrollmentRepository = unitOfWork.Repository<TeacherEnrollment>();
            _enrollmentRepository = enrollmentRepository;
        }
        public List<TeacherEnrollmentVM> GetTeacherEnrollmentByClassId(Guid classId)
        {
            return _enrollmentRepository.GetTeacherEnrollmentByClassId(classId);
        }


        public IQueryable<TeacherEnrollment> GetTeacherEnrollmentByTeacherId(Guid TeacherId)
        {
            return _teacherEnrollmentRepository.Query(string.Format("select * from TeacherEnrollments where teacherId='{0}'", TeacherId));
        }
    }
}
