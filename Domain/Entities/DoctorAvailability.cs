using Core.DataAccess;

namespace Domain.Entities
{
    public class DoctorAvailability : Entity<int>
    {
		public int? DoctorId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public virtual Doctor? Doctor { get; set; }
		public virtual ICollection<Appointment> Appointments { get; set; }

        public DoctorAvailability()
        {
            Appointments = new HashSet<Appointment>();
        }

        public DoctorAvailability(int id, int? doctorId, DateTime startTime, DateTime endTime, Doctor? doctor)
            : this()
        {
            Id = id;
            DoctorId = doctorId;
            StartTime = startTime;
            EndTime = endTime;
            Doctor = doctor;
        }
    }
}
