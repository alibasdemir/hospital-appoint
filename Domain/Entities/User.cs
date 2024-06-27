using Core.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseUser
    {
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? PhotoUrl { get; set; }
        public string UserType { get; set; }
		public virtual ICollection<Feedback> Feedbacks { get; set; }

		public User()
        {
        }

        public User(
            int id, 
            string firstName,
            string lastName,
            string email,
            byte[] passwordSalt,
            byte[] passwordHash, 
            Gender? gender, 
            DateTime? birthDate, 
            string? phoneNumber, 
            City? city, 
            string? address, 
            string? photoUrl,
            string userType
        )
            : this()     
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            City = city;
            Address = address;
            PhotoUrl = photoUrl;
            UserType = userType;
        }
    }
}
