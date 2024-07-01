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

            string password2 = "string";
            byte[] passwordHash2, passwordSalt2;
            HashingHelper.CreatePasswordHash(password2, out passwordHash2, out passwordSalt2);

            string password3 = "johndoe";
            byte[] passwordHash3, passwordSalt3;
            HashingHelper.CreatePasswordHash(password3, out passwordHash3, out passwordSalt3);

            string password4 = "janesmith";
            byte[] passwordHash4, passwordSalt4;
            HashingHelper.CreatePasswordHash(password4, out passwordHash4, out passwordSalt4);

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
                    PasswordSalt = passwordSalt2,
                    PasswordHash = passwordHash2,
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
                    PasswordSalt = passwordSalt2,
                    PasswordHash = passwordHash2,
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
                    PasswordSalt = passwordSalt2,
                    PasswordHash = passwordHash2,
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
                    Id = 5,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe",
                    PasswordSalt = passwordSalt3,
                    PasswordHash = passwordHash3,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1980, 01, 01),
                    PhoneNumber = "1111111",
                    City = City.Istanbul,
                    Address = "address",
                    PhotoUrl = "photoUrl",
                    UserType = "patient",
                },
                new User
                {
                    Id = 6,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "janesmith",
                    PasswordSalt = passwordSalt4,
                    PasswordHash = passwordHash4,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1975, 02, 15),
                    PhoneNumber = "1111111",
                    City = City.Ankara,
                    Address = "address",
                    PhotoUrl = "photoUrl",
                    UserType = "patient",
                },
            };
            builder.HasData(userSeeds);
        }
    }
}
