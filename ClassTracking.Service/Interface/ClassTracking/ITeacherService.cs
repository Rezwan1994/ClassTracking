using ClassTracking.Domain.Common;
using ClassTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Service.Interface.ClassTracking
{
    public interface ITeacherService : IBaseService<Teacher>
    {
        public IQueryable<Teacher> GetTeacherByTeacherId(Guid teacherId);
        Teacher GetTeacherByClassId(Guid classId);
    }
}
