using ClassTracking.Domain.DbContexts;
using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Interface.ClassTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClassTracking.Repository.Implementation.ClassTracking
{
    public class TeacherEnrollmentRepository : Repository<TeacherEnrollment>, ITeacherEnrollmentRepository
    {
        private readonly ClassTrackingDbContext _context;
        public TeacherEnrollmentRepository(ClassTrackingDbContext context) : base(context)
        {
            _context = context;
        }
        public List<TeacherEnrollmentVM> GetTeacherEnrollmentByClassId(Guid classId)
        {
            string rawQuery = @"select te.*,t.Name TeacherName from TeacherEnrollments te
                                        left join Teachers t on t.teacherId= te.teacherId 
                                         where te.classId='{0}'";
            string sqlQuery = string.Format(rawQuery, classId);
          
           // return _context.Database.SqlQuery<TeacherEnrollment>(sqlQuery).ToList();
            //string sqlQuery = string.Format(rawQuery, CustomerId, TypeQuery);
            var enrollList = _context.ExecSQL<TeacherEnrollmentVM>(sqlQuery).ToList();
            return enrollList;

        }
    }
}
