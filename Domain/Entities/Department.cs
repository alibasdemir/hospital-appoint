using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department : Entity
    {
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set;}
        public ICollection<Doctor> Doctors { get; set; }
    }
}
