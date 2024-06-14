using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Admins.Queries.GetById
{
    public class GetByIdAdminResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<AdminAction> AdminActions { get; set; }

    }
}
