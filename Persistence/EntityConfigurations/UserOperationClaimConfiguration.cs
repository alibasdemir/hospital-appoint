using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            UserOperationClaim[] userOperationClaimSeeds =
                {
                new UserOperationClaim
                {
                    Id = 1,
                    BaseUserId = 1,
                    OperationClaimId = 1, // users.admin
                },
                new UserOperationClaim
                {
                    Id = 2,
                    BaseUserId = 1,
                    OperationClaimId = 7, // doctors.admin
                },
                new UserOperationClaim
                {
                    Id = 3,
                    BaseUserId = 1,
                    OperationClaimId = 13, // patients.admin
                },
                new UserOperationClaim
                {
                    Id = 4,
                    BaseUserId = 1,
                    OperationClaimId = 19, // doctorAvailabilities.admin
                },
                new UserOperationClaim
                {
                    Id = 5,
                    BaseUserId = 1,
                    OperationClaimId = 25, // patientReports.admin
                },
                new UserOperationClaim
                {
                    Id = 6,
                    BaseUserId = 1,
                    OperationClaimId = 31, // appointments.admin
                },
                new UserOperationClaim
                {
                    Id = 7,
                    BaseUserId = 1,
                    OperationClaimId = 37, // departments.admin
                },
                new UserOperationClaim
                {
                    Id = 8,
                    BaseUserId = 1,
                    OperationClaimId = 43, // operationClaims.admin
                },
                new UserOperationClaim
                {
                    Id = 9,
                    BaseUserId = 1,
                    OperationClaimId = 49, // userOperationClaims.admin
                },
                new UserOperationClaim
                {
                    Id = 10,
                    BaseUserId = 1,
                    OperationClaimId = 55, // feedbacks.admin
                },
                new UserOperationClaim
                {
                    Id = 11,
                    BaseUserId = 1,
                    OperationClaimId = 61, // notifications.admin
                },
                new UserOperationClaim
                {
                    Id = 12,
                    BaseUserId = 1,
                    OperationClaimId = 67, // supportRequests.admin
                },
                new UserOperationClaim
                {
                    Id = 13,
                    BaseUserId = 2,
                    OperationClaimId = 8, // doctors.read
                },
                new UserOperationClaim
                {
                    Id = 14,
                    BaseUserId = 2,
                    OperationClaimId = 9, // doctors.write
                },
                new UserOperationClaim
                {
                    Id = 15,
                    BaseUserId = 2,
                    OperationClaimId = 11, // doctors.update
                },
                new UserOperationClaim
                {
                    Id = 16,
                    BaseUserId = 2,
                    OperationClaimId = 20, // doctorAvailabilities.read
                },
                new UserOperationClaim
                {
                    Id = 17,
                    BaseUserId = 2,
                    OperationClaimId = 21, // doctorAvailabilities.write
                },
                new UserOperationClaim
                {
                    Id = 18,
                    BaseUserId = 2,
                    OperationClaimId = 22, // doctorAvailabilities.add
                },
                new UserOperationClaim
                {
                    Id = 19,
                    BaseUserId = 2,
                    OperationClaimId = 23, // doctorAvailabilities.update
                },
                new UserOperationClaim
                {
                    Id = 20,
                    BaseUserId = 2,
                    OperationClaimId = 26, // patientReports.read
                },
                new UserOperationClaim
                {
                    Id = 21,
                    BaseUserId = 2,
                    OperationClaimId = 27, // patientReports.write
                },
                new UserOperationClaim
                {
                    Id = 22,
                    BaseUserId = 2,
                    OperationClaimId = 28, // patientReports.add
                },
                new UserOperationClaim
                {
                    Id = 23,
                    BaseUserId = 2,
                    OperationClaimId = 29, // patientReports.update
                },
                new UserOperationClaim
                {
                    Id = 24,
                    BaseUserId = 2,
                    OperationClaimId = 32, // appointments.read
                },
            };
            builder.HasData(userOperationClaimSeeds);
        }
    }
}
