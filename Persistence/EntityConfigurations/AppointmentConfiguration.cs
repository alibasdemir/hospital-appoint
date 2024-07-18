using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            Appointment[] appointmentSeeds =
            {
                new Appointment
                {
                    Id = 1,
                    PatientId = 1,
                    DoctorAvailabilityId = 1,
                    Status = AppointmentStatus.Completed,
                    StartTime = new DateTime(2024, 06, 30, 10, 30, 0),
                    EndTime = new DateTime(2024, 06, 30, 11, 0, 0)
                },
                new Appointment
                {
                    Id = 2,
                    PatientId = 2,
                    DoctorAvailabilityId = 1,
                    Status = AppointmentStatus.Completed,
                    StartTime = new DateTime(2024, 06, 30, 11, 00, 0),
                    EndTime = new DateTime(2024, 06, 30, 12, 0, 0)
                },
                new Appointment
                {
                    Id = 3,
                    PatientId = 2,
                    DoctorAvailabilityId = 4,
                    Status = AppointmentStatus.Completed,
                    StartTime = new DateTime(2024, 07, 04, 9, 30, 0),
                    EndTime = new DateTime(2024, 07, 04, 10, 0, 0)
                },
            };
            builder.HasData(appointmentSeeds);
        }
    }
}
