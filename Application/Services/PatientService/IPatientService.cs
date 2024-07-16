using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PatientService
{
	public interface IPatientService
	{
		Task<bool> PatientValidationById(int id);

        Task AddPatientAsync(Patient patient);
		Task<User> GetUserAsync(int patientId);

	}
}
