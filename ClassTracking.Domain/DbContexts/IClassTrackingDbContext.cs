using ClassTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.DbContexts
{
    public interface IClassTrackingDbContext
    {
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentClassMap> StudentClassMaps { get; set; }
        DbSet<TeacherEnrollment> TeacherEnrollments { get; set; }
        DbSet<Class> Classes { get; set; }
    }
}
