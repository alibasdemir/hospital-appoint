using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using Application.Services.OperationClaimService;
using Application.Services.PatientService;
using Application.Services.UserOperationClaimService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Domain.Entities;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepisotory;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserBusinessRules(IUserRepository userRepisotory, IDoctorService doctorService, IPatientService patientService, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService)
        {
            _userRepisotory = userRepisotory;
            _doctorService = doctorService;
            _patientService = patientService;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task UserEmailAlreadyUsed(string email)
        {
            User? user = await _userRepisotory.GetAsync(i => i.Email == email);
            if (user != null)
            {
                throw new BusinessException(UsersMessages.EmailAlreadyUsed);
            }
        }

        public async Task UserShouldBeExist(int id)
        {
            User? user = await _userRepisotory.GetAsync(i => i.Id == id);
            if (user == null)
            {
                throw new BusinessException(UsersMessages.UserNotExists);
            }
        }

        public async Task UserDeleteControl(int id)
        {
            User? user = await _userRepisotory.GetAsync(i => i.Id == id);
            if (user == null || user.IsDeleted == true)
            {
                throw new BusinessException(UsersMessages.UserNotExists);
            }
        }

        public async Task DoctorOrPatientDelete(int id)
        {
            User? user = await _userRepisotory.GetAsync(i => i.Id == id);
            Doctor? doctor = await _doctorService.DoctorGetByUserId(id);
            Patient? patient = await _patientService.PatientGetByUserId(id);
            if (user.UserType == "doctor")
            {
                doctor.IsDeleted = true;
                _doctorService.UpdateDoctorAsync(doctor);
            }
            if (user.UserType == "patient")
            {
                patient.IsDeleted = true;
                _patientService.UpdatePatientAsync(patient);
            }
        }

        public async Task AddUserWithUserType(User user, string userType)
        {
            if (user.UserType.ToLower() == "doctor")
            {
                await _userRepisotory.AddAsync(user);

                Doctor doctor = new Doctor
                {
                    UserId = user.Id,
                };

                await _doctorService.AddDoctorAsync(doctor);

            }
            else if (user.UserType.ToLower() == "patient")
            {
                await _userRepisotory.AddAsync(user);

                Patient patient = new Patient
                {
                    UserId = user.Id,
                };

                await _patientService.AddPatientAsync(patient);
            }
            else
            {
                throw new BusinessException(UsersMessages.ValidUserType);
            }
        }

        public async Task AssignClaimsToUserBasedOnTypeAsync(User user, string userType)
        {
            if (userType == "patient")
            {
                var operationClaimIds = new List<int> { 34, 35, 58, 59, 60, 17, 5 };
                foreach (var operationClaimId in operationClaimIds)
                {
                    OperationClaim operationClaim = await _operationClaimService.GetOperationClaimByIdAsync(operationClaimId);
                    if (operationClaim == null)
                    {
                        throw new BusinessException($"Operation claim with ID {operationClaimId} not found.");
                    }
                    await _userOperationClaimService.AssignOperationClaimToUser(user.Id, operationClaimId);
                }
            }
            else if (userType == "doctor")
            {
                var operationClaimIds = new List<int> { 11, 22, 23, 28, 29, 30, 58, 59, 60, 5 };
                foreach (var operationClaimId in operationClaimIds)
                {
                    OperationClaim operationClaim = await _operationClaimService.GetOperationClaimByIdAsync(operationClaimId);
                    if (operationClaim == null)
                    {
                        throw new BusinessException($"Operation claim with ID {operationClaimId} not found.");
                    }
                    await _userOperationClaimService.AssignOperationClaimToUser(user.Id, operationClaimId);
                }
            }
            else
            {
                throw new BusinessException(UsersMessages.ValidUserType);
            }
        }

        public async Task UserEmailCanBeUpdated(int userId, string newEmail)
        {
            User? user = await _userRepisotory.GetAsync(u => u.Id == userId);
            if (user.Email == newEmail)
            {
                return;
            }
            User? existingUser = await _userRepisotory.GetAsync(u => u.Email == newEmail && u.Id != userId);
            if (existingUser != null)
            {
                throw new BusinessException(UsersMessages.EmailAlreadyUsed);
            }
        }
    }
}
