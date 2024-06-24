using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            Doctor[] doctorSeeds =
            {
                new Doctor
                {
                    Id = 1,
                    SpecialistLevel = "Prof",
                    YearsOfExperience = 25,
                    Biography = "With over 25 years of experience, this distinguished Professor of Orthopedics specializes in orthopedic surgery. They completed their medical degree, residency, and fellowship at prestigious institutions, focusing on innovative surgical techniques and groundbreaking research. A prolific author and keynote speaker, they have contributed extensively to the academic community and are actively involved in mentoring future orthopedic surgeons. They are a respected member of the American Academy of Orthopaedic Surgeons (AAOS). Their clinical interests include joint replacement, sports medicine, and minimally invasive procedures. Known for their compassionate approach, they are dedicated to achieving excellent outcomes for their patients and are committed to community service.",
                    UserId = 2,
                    DepartmentId = 3,
                },
                new Doctor 
                {
                    Id = 2,
                    SpecialistLevel = "Doç",
                    YearsOfExperience = 15,
                    Biography = "Biography",
                    UserId = 3,
                    DepartmentId = 1,
                },
                new Doctor
                {
                    Id = 3,
                    SpecialistLevel = "Uzm",
                    YearsOfExperience = 10,
                    Biography = "Biography",
                    UserId = 4,
                    DepartmentId = 2,
                },
            };
            builder.HasData(doctorSeeds);
        }
    }
}
