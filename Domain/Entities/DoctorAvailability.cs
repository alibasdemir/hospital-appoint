﻿using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DoctorAvailability : Entity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public User Doctor { get; set; }
        public DateTime AvailableDate { get; set; } // Doktorun müsait olduğu tarih
        public DateTime StartTime { get; set; } // Doktorun müsaitlik başlangıç saati
        public DateTime EndTime { get; set; } // Doktorun müsaitlik bitiş saati
        //public ICollection<Appointment> Appointments { get; set; }
    }
}
