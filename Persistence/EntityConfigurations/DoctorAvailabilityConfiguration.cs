using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class DoctorAvailabilityConfiguration : IEntityTypeConfiguration<DoctorAvailability>
    {
        public void Configure(EntityTypeBuilder<DoctorAvailability> builder)
        {
            DoctorAvailability[] doctorAvabilitySeeds =
            {
                new DoctorAvailability
                {
                    Id = 1,
                    DoctorId = 1,
                    StartTime = new DateTime(2024, 06, 30, 9, 0, 0),
                    EndTime = new DateTime(2024, 06, 30, 17, 0, 0)
                },
                new DoctorAvailability
                {
                    Id = 2,
                    DoctorId = 2,
                    StartTime = new DateTime(2024, 06, 30, 8, 0, 0),
                    EndTime = new DateTime(2024, 06, 30, 15, 0, 0)
                },
                new DoctorAvailability
                {
                    Id = 3,
                    DoctorId = 1,
                    StartTime = new DateTime(2024, 07, 01, 10, 0, 0),
                    EndTime = new DateTime(2024, 07, 01, 18, 0, 0)
                },
                new DoctorAvailability
                {
                    Id = 4,
                    DoctorId = 3,
                    StartTime = new DateTime(2024, 07, 04, 8, 30, 0),
                    EndTime = new DateTime(2024, 07, 04, 16, 45, 0)
                },
            };
            builder.HasData(doctorAvabilitySeeds);
        }
    }
}
