using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class PatientReportConfiguration : IEntityTypeConfiguration<PatientReport>
    {
        public void Configure(EntityTypeBuilder<PatientReport> builder)
        {
            PatientReport[] patientReportSeeds =
            {
                new PatientReport
                {
                    Id = 1,
                    AppointmentId = 1,
                    Title = "Test",
                    Details = "Test"
                },
                new PatientReport
                {
                    Id = 2,
                    AppointmentId = 2,
                    Title = "Test2",
                    Details = "Test2"
                },
            };
            builder.HasData(patientReportSeeds);
        }
    }
}
