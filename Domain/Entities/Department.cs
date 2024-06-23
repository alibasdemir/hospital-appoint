using Core.DataAccess;

namespace Domain.Entities
{
    public class Department : Entity<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

        public Department()
        {
        }

        public Department(
            int id,
            string? name,
            string? description
        )
            : this()
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
