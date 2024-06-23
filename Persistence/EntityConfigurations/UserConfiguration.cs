using Core.Hashing;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string password = "admin";
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            User[] userSeeds =
            {
                new User
                {
                    Id = 1,
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1900, 06, 22),
                    PhoneNumber = "1111111",
                    City = City.İzmir,
                    Address = "address",
                    PhotoUrl = "photoUrl"
                }
            };
            builder.HasData(userSeeds);
        }
    }
}
