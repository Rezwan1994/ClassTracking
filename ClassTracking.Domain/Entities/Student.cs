using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Nationality { get; set; }
        public DateTime EnrollDate { get; set; }
        public string SessionYear { get; set; }
    }
}
