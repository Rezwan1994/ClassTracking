using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Entities
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public bool IsAssigned { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
