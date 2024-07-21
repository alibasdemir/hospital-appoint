using Application.Features.Auth.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using Application.Services.OperationClaimService;
using Application.Services.PatientService;
using Application.Services.UserOperationClaimService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepisotory;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthBusinessRules(IUserRepository userRepisotory, IDoctorService doctorService, IPatientService patientService, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService)
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
                throw new Exception(AuthMessages.EmailAlreadyUsed);
            }
        }

        public async Task UserDeleteControl(string email)
        {
            User? user = await _userRepisotory.GetAsync(i => i.Email == email);
            if (user == null || user.IsDeleted == true)
            {
                throw new BusinessException(AuthMessages.UserNotExists);
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
                throw new BusinessException(AuthMessages.ValidUserType);
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
            } else if (userType == "doctor")
            {
                var operationClaimIds = new List<int> { 11, 22, 23, 28, 29, 30, 58, 59, 60, 5 };
                foreach (var operationClaimId in operationClaimIds)
                {
                    OperationClaim operationClaim = await _operationClaimService.GetOperationClaimByIdAsync(operationClaimId);
                    if(operationClaim == null)
                    {
                        throw new BusinessException($"Operation claim with ID {operationClaimId} not found.");
                    }
                    await _userOperationClaimService.AssignOperationClaimToUser(user.Id, operationClaimId);
                }
            }
            else
            {
                throw new BusinessException(AuthMessages.ValidUserType);
            }
        }
    }
}
