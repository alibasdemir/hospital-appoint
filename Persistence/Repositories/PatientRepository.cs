using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PatientRepository : EfRepositoryBase<Patient, HospitalAppointDbContext>, IPatientRepository
    {
        public PatientRepository(HospitalAppointDbContext context) : base(context)
        {
        }
		public async Task<User> GetUserAsync(int patientId)
		{
			return await Context.Patients
				.Include(p => p.User)
				.Where(p => p.Id == patientId)
				.Select(p => p.User)
				.FirstOrDefaultAsync();
		}
	}
}
