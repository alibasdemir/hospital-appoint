using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SupportRequestRepository : EfRepositoryBase<SupportRequest, HospitalAppointDbContext>, ISupportRequestRepository
    {
        public SupportRequestRepository(HospitalAppointDbContext context) : base(context)
        {
        }
    }
}
