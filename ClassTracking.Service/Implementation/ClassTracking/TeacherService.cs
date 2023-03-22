using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Implementation;
using ClassTracking.Repository.Interface;
using ClassTracking.Repository.UnitOfWork;
using ClassTracking.Service.Interface.ClassTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTracking.Repository.Interface.ClassTracking;
using ClassTracking.Domain.Common;

namespace ClassTracking.Service.Implementation.ClassTracking
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly ITeacherRepository _teacherExtRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork, ITeacherRepository teacherExtRepository)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherRepository = unitOfWork.Repository<Teacher>();
            _teacherExtRepository = teacherExtRepository;
        }
        public IQueryable<Teacher> GetTeacherByTeacherId(Guid teacherId)
        {
            return _teacherRepository.Query(string.Format("select * from teachers where teacherid='{0}'", teacherId));
        }
        public Teacher GetTeacherByClassId(Guid classId)
        {
            return _teacherExtRepository.GetTeacherByClassId(classId);
        }
    }
}
