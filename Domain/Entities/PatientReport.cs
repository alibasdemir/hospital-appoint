using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientReport : Entity<int>
    {
        public int AppointmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        //public int PatientId { get; set; }
        //public virtual Patient Patient { get; set; }
        //public int DoctorId { get; set; }
        //public virtual Doctor Doctor { get; set; }
        public virtual Appointment Appointment { get; set; }

    }
}
