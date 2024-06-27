using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            OperationClaim[] operationClaimSeeds =
                {
                new OperationClaim
                {
                    Id = 1,
                    Name = "users.admin"
                },
                new OperationClaim
                {
                    Id = 2,
                    Name = "users.read"
                },
                new OperationClaim
                {
                    Id = 3,
                    Name = "users.write"
                },
                new OperationClaim
                {
                    Id = 4,
                    Name = "users.add"
                },
                new OperationClaim
                {
                    Id = 5,
                    Name = "users.update"
                },
                new OperationClaim
                {
                    Id = 6,
                    Name = "users.delete"
                },
                new OperationClaim
                {
                    Id = 7,
                    Name = "doctors.admin"
                },
                new OperationClaim
                {
                    Id = 8,
                    Name = "doctors.read"
                },
                new OperationClaim
                {
                    Id = 9,
                    Name = "doctors.write"
                },
                new OperationClaim
                {
                    Id = 10,
                    Name = "doctors.add"
                },
                new OperationClaim
                {
                    Id = 11,
                    Name = "doctors.update"
                },
                new OperationClaim
                {
                    Id = 12,
                    Name = "doctors.delete"
                },
                new OperationClaim
                {
                    Id = 13,
                    Name = "patients.admin"
                },
                new OperationClaim
                {
                    Id = 14,
                    Name = "patients.read"
                },
                new OperationClaim
                {
                    Id = 15,
                    Name = "patients.write"
                },
                new OperationClaim
                {
                    Id = 16,
                    Name = "patients.add"
                },
                new OperationClaim
                {
                    Id = 17,
                    Name = "patients.update"
                },
                new OperationClaim
                {
                    Id = 18,
                    Name = "patients.delete"
                },
                new OperationClaim
                {
                    Id = 19,
                    Name = "doctorAvailabilities.admin"
                },
                new OperationClaim
                {
                    Id = 20,
                    Name = "doctorAvailabilities.read"
                },
                new OperationClaim
                {
                    Id = 21,
                    Name = "doctorAvailabilities.write"
                },
                new OperationClaim
                {
                    Id = 22,
                    Name = "doctorAvailabilities.add"
                },
                new OperationClaim
                {
                    Id = 23,
                    Name = "doctorAvailabilities.update"
                },
                new OperationClaim
                {
                    Id = 24,
                    Name = "doctorAvailabilities.delete"
                },
                new OperationClaim
                {
                    Id = 25,
                    Name = "patientReports.admin"
                },
                new OperationClaim
                {
                    Id = 26,
                    Name = "patientReports.read"
                },
                new OperationClaim
                {
                    Id = 27,
                    Name = "patientReports.write"
                },
                new OperationClaim
                {
                    Id = 28,
                    Name = "patientReports.add"
                },
                new OperationClaim
                {
                    Id = 29,
                    Name = "patientReports.update"
                },
                new OperationClaim
                {
                    Id = 30,
                    Name = "patientReports.delete"
                },
                new OperationClaim
                {
                    Id = 31,
                    Name = "appointments.admin"
                },
                new OperationClaim
                {
                    Id = 32,
                    Name = "appointments.read"
                },
                new OperationClaim
                {
                    Id = 33,
                    Name = "appointments.write"
                },
                new OperationClaim
                {
                    Id = 34,
                    Name = "appointments.add"
                },
                new OperationClaim
                {
                    Id = 35,
                    Name = "appointments.update"
                },
                new OperationClaim
                {
                    Id = 36,
                    Name = "appointments.delete"
                },
                new OperationClaim
                {
                    Id = 37,
                    Name = "departments.admin"
                },
                new OperationClaim
                {
                    Id = 38,
                    Name = "departments.read"
                },
                new OperationClaim
                {
                    Id = 39,
                    Name = "departments.write"
                },
                new OperationClaim
                {
                    Id = 40,
                    Name = "departments.add"
                },
                new OperationClaim
                {
                    Id = 41,
                    Name = "departments.update"
                },
                new OperationClaim
                {
                    Id = 42,
                    Name = "departments.delete"
                },
                new OperationClaim
                {
                    Id = 43,
                    Name = "operationClaims.admin"
                },
                new OperationClaim
                {
                    Id = 44,
                    Name = "operationClaims.read"
                },
                new OperationClaim
                {
                    Id = 45,
                    Name = "operationClaims.write"
                },
                new OperationClaim
                {
                    Id = 46,
                    Name = "operationClaims.add"
                },
                new OperationClaim
                {
                    Id = 47,
                    Name = "operationClaims.update"
                },
                new OperationClaim
                {
                    Id = 48,
                    Name = "operationClaims.delete"
                },
                new OperationClaim
                {
                    Id = 49,
                    Name = "userOperationClaims.admin"
                },
                new OperationClaim
                {
                    Id = 50,
                    Name = "userOperationClaims.read"
                },
                new OperationClaim
                {
                    Id = 51,
                    Name = "userOperationClaims.write"
                },
                new OperationClaim
                {
                    Id = 52,
                    Name = "userOperationClaims.add"
                },
                new OperationClaim
                {
                    Id = 53,
                    Name = "userOperationClaims.update"
                },
                new OperationClaim
                {
                    Id = 54,
                    Name = "userOperationClaims.delete"
                },
                new OperationClaim
                {
                    Id = 55,
                    Name = "feedbacks.admin"
                },
                new OperationClaim
                {
                    Id = 56,
                    Name = "feedbacks.read"
                },
                new OperationClaim
                {
                    Id = 57,
                    Name = "feedbacks.write"
                },
                new OperationClaim
                {
                    Id = 58,
                    Name = "feedbacks.add"
                },
                new OperationClaim
                {
                    Id = 59,
                    Name = "feedbacks.update"
                },
                new OperationClaim
                {
                    Id = 60,
                    Name = "feedbacks.delete"
                },
                new OperationClaim
                {
                    Id = 61,
                    Name = "notifications.admin"
                },
                new OperationClaim
                {
                    Id = 62,
                    Name = "notifications.read"
                },
                new OperationClaim
                {
                    Id = 63,
                    Name = "notifications.write"
                },
                new OperationClaim
                {
                    Id = 64,
                    Name = "notifications.add"
                },
                new OperationClaim
                {
                    Id = 65,
                    Name = "notifications.update"
                },
                new OperationClaim
                {
                    Id = 66,
                    Name = "notifications.delete"
                },
                new OperationClaim
                {
                    Id = 67,
                    Name = "supportRequests.admin"
                },
                new OperationClaim
                {
                    Id = 68,
                    Name = "supportRequests.read"
                },
                new OperationClaim
                {
                    Id = 69,
                    Name = "supportRequests.write"
                },
                new OperationClaim
                {
                    Id = 70,
                    Name = "supportRequests.add"
                },
                new OperationClaim
                {
                    Id = 71,
                    Name = "supportRequests.update"
                },
                new OperationClaim
                {
                    Id = 72,
                    Name = "supportRequests.delete"
                }
            };
            builder.HasData(operationClaimSeeds);
        }
    }
}
