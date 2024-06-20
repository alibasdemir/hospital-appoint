using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, HospitalAppointDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(HospitalAppointDbContext context) : base(context)
        {
        }
    }
}
