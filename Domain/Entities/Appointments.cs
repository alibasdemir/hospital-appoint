using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointments : Entity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public User Patient { get; set; }
        public int DoctorId { get; set; }
        public User Doctor { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public enum AppointmentStatus
    {
        Booked,
        Cancelled,
        Completed
    }
}
