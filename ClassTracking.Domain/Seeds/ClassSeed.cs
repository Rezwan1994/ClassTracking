using ClassTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Seeds
{
    public class ClassSeed
    {
        internal Class[] classes
        {
            get
            {
                return new Class[]
                {
                    new Class{ ClassId=Guid.NewGuid(), Name = "Class One" },
                    new Class{ ClassId=Guid.NewGuid(),Name = "Class Two" },
                    new Class{ClassId=Guid.NewGuid(), Name = "Class Three"},

                    new Class{ ClassId=Guid.NewGuid(), Name = "Class Four" },
                    new Class{ ClassId=Guid.NewGuid(),Name = "Class Five" },
                    new Class{ClassId=Guid.NewGuid(), Name = "Class Six"}
                };
            }
        }
    }
}
