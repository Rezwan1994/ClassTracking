using ClassTracking.Domain.Common;
using ClassTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Repository.Interface.ClassTracking
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudentByClassId(FilterModel filter,Guid classId);
    }
}
