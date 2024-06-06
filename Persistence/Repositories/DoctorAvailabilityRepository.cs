using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class DoctorAvailabilityRepository : EfRepositoryBase<DoctorAvailability, HospitalAppointDbContext>
    {
        public DoctorAvailabilityRepository(HospitalAppointDbContext context) : base(context)
        {
        }
    }
}
