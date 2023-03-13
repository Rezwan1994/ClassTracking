using ClassTracking.Domain.DbContexts;
using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Interface.ClassTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Repository.Implementation.ClassTracking
{
    public class TeacherRepository : Repository<TeacherEnrollment>, ITeacherRepository
    {
        private readonly ClassTrackingDbContext _context;
        public TeacherRepository(ClassTrackingDbContext context) : base(context)
        {
            _context = context;
        }
        public Teacher GetTeacherByClassId(Guid classId)
        {
            string rawQuery = @"select * from Teachers t
                                left join TeacherEnrollments te on te.TeacherId = t.TeacherId
                                left join Classes c on c.ClassId = '{0}'";
            string sqlQuery = string.Format(rawQuery, classId);

            // return _context.Database.SqlQuery<TeacherEnrollment>(sqlQuery).ToList();
            //string sqlQuery = string.Format(rawQuery, CustomerId, TypeQuery);
            var teacher = _context.ExecSQL<Teacher>(sqlQuery).ToList().FirstOrDefault();
            return teacher;

        }
    }
}
