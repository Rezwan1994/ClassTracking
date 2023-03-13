using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Entities
{
    public class StudentClassMap : IEntity<int>
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }
    }
}
