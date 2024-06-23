using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ISupportRequestRepository : IAsyncRepository<SupportRequest>, IRepository<SupportRequest>
    {
    }
}
