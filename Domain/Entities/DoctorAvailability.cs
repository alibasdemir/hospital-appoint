using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DoctorAvailability : Entity<int>
    {
		public int? DoctorId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public Doctor Doctor { get; set; }
		public ICollection<Appointment> Appointments { get; set; }
	}
}
