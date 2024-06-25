using Core.Hashing;
using Domain.Entities;
using Domain.Enums;
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
                    City = City.Izmir,
                    Address = "address",
                    PhotoUrl = "photoUrl",
                    UserType = "admin",
                },
                new User
                {
                    Id = 2,
                    FirstName = "string",
                    LastName = "string",
                    Email = "string",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1900, 06, 22),
                    PhoneNumber = "1111111",
                    City = City.Izmir,
                    Address = "address",
                    PhotoUrl = "photoUrl",
                    UserType = "doctor",
                },
                new User
                {
                    Id = 3,
                    FirstName = "string3",
                    LastName = "string3",
                    Email = "string3",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1900, 06, 22),
                    PhoneNumber = "1111111",
                    City = City.Izmir,
                    Address = "address",
                    PhotoUrl = "photoUrl",
                    UserType = "doctor",
                },
                new User
                {
                    Id = 4,
                    FirstName = "string4",
                    LastName = "string4",
                    Email = "string4",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1900, 06, 22),
                    PhoneNumber = "1111111",
                    City = City.Izmir,
                    Address = "address",
                    PhotoUrl = "photoUrl",
                    UserType = "doctor",
                },
            };
            builder.HasData(userSeeds);
        }
    }
}
