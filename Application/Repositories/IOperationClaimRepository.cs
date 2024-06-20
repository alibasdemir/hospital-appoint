using Core.DataAccess;
using Core.Entities;

namespace Application.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }
}
