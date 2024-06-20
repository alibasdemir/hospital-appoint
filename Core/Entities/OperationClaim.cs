using Core.DataAccess;

namespace Core.Entities
{
    public class OperationClaim : Entity<int>
    {
        public string Name { get; set; }
    }
}
