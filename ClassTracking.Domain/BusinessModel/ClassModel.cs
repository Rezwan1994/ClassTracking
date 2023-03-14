using ClassTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.BusinessModel
{
    public class ClassModel
    {
        public Class classobj { get; set; }
        public Teacher teacherobj { get; set; }
        public List<Student> studentList { get; set; }
        public int TotalStudent { get; set; }
        public int MaxStudent { get; set; }
    }
}
