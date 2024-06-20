using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, HospitalAppointDbContext>,
        IOperationClaimRepository
    {
        public OperationClaimRepository(HospitalAppointDbContext context) : base(context)
        {
        }
    }
}
