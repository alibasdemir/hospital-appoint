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
                    OperationClaimId = 1, // admin
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
