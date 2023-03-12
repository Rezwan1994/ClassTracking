using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Implementation.ClassTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Repository.Interface.ClassTracking
{
    public interface ITeacherEnrollmentRepository
    {
        public List<TeacherEnrollmentVM> GetTeacherEnrollmentByClassId(Guid classId);
     
    }
}
