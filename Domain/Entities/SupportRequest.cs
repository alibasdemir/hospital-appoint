using Core.DataAccess;

namespace Domain.Entities
{
    public class SupportRequest : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
