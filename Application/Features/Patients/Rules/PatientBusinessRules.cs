using Application.Features.Patients.Constants;
using Application.Repositories;
using Application.Services.UserService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Patients.Rules
{
    public class PatientBusinessRules
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserService _userService;

        public PatientBusinessRules(IPatientRepository patientRepository, IUserService userService)
        {
            _patientRepository = patientRepository;
            _userService = userService;
        }

        public async Task UserShouldBeExist(int id)
        {
            User? user = await _userService.GetUserByIdAsync(id);
            {
                if (user == null || user.IsDeleted == true)
                {
                    throw new BusinessException(PatientsMessages.UserNotExists);
                }
            }
        }

        public async Task PatientShouldBeExist(int id)
        {
            Patient? patient = await _patientRepository.GetAsync(i => i.Id == id);
            if (patient == null)
            {
                throw new BusinessException(PatientsMessages.PatientNotExists);
            }
        }

        public async Task PatientDeleteControl(int id)
        {
            Patient? patient = await _patientRepository.GetAsync(i => i.Id == id);
            if (patient == null || patient.IsDeleted == true)
            {
                throw new BusinessException(PatientsMessages.PatientNotExists);
            }
        }

        public async Task PatientDeleteWithUser(int? id)
        {
            Patient? patient = await _patientRepository.GetAsync(i => i.Id == id);
            
            if (patient.UserId.HasValue)
            {
                User? user = await _userService.GetUserByIdAsync(patient.UserId.Value);
                if (user != null)
                {
                    user.IsDeleted = true;
                    await _userService.UpdateUserAsync(user);
                }
            }      
        }
    }
}
