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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ClassTrackingDbContext _context;
        public StudentRepository(ClassTrackingDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
