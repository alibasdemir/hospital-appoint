using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
