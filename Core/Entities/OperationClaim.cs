using Core.DataAccess;

namespace Core.Entities
{
    public class OperationClaim : Entity<int>
    {
        public string Name { get; set; }

        public OperationClaim()
        {
        }

        public OperationClaim(
            int id,
            string name
        )
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}
