using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Entities
{
    public  class TeacherEnrollment : IEntity<int>
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ClassId { get; set; }
        public DateTime AssignDate { get; set; }
    }
    [NotMapped]
    public class TeacherEnrollmentVM : TeacherEnrollment
    {
        public string TeacherName { get; set; }
    }
}
