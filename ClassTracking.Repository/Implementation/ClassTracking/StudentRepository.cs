﻿using ClassTracking.Domain.DbContexts;
using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Interface.ClassTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Repository.Implementation.ClassTracking
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ClassTrackingDbContext _context;
        public StudentRepository(ClassTrackingDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Student> GetAllStudentByClassId(Guid classId)
        {
            string rawQuery = @"select * from Students s
                            left join StudentClassMaps sm on sm.StudentId = s.StudentId
                            left join Classes c on c.ClassId = '{0}'";
            string sqlQuery = string.Format(rawQuery, classId);

            // return _context.Database.SqlQuery<TeacherEnrollment>(sqlQuery).ToList();
            //string sqlQuery = string.Format(rawQuery, CustomerId, TypeQuery);
            var studentList = _context.ExecSQL<Student>(sqlQuery).ToList();
            return studentList;
        }
    }
}
