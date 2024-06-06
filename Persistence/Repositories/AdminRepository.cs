using Core.DataAccess;
using Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AdminRepository : EfRepositoryBase<Admin, HospitalAppointDbContext>
    {
        public AdminRepository(HospitalAppointDbContext context) : base(context)
        {
        }
    }
}
