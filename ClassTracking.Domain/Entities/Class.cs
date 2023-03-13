using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Entities
{
    public class Class : IEntity<int>
    {
        public int Id { get; set; }
        public Guid ClassId { get; set; }
        public string Name { get; set; }
    }
  
}
