using Core.DataAccess;

namespace Domain.Entities
{
    public class SupportRequest : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public SupportRequest()
        {
        }

        public SupportRequest(int id, string firstName, string lastName, string email, string phoneNumber, string title, string content)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Title = title;
            Content = content;
        }
    }
}
