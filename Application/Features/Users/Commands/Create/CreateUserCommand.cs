using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using Application.Services.OperationClaimService;
using Application.Services.PatientService;
using Application.Services.UserOperationClaimService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Core.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>, ILoggableRequest, ISecuredRequest
    {
        public string[] RequiredRoles => new[] { Admin, Write, Add };
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IPatientService _patientService;
            private readonly IDoctorService _doctorService;
            private readonly IUserOperationClaimService _userOperationClaimService;
            private readonly IOperationClaimService _operationClaimService;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPatientService patientService, IDoctorService doctorService, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _patientService = patientService;
                _doctorService = doctorService;
                _userOperationClaimService = userOperationClaimService;
                _operationClaimService = operationClaimService;
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User? existingUser = await _userRepository.GetAsync(u => u.Email == request.Email);
                if (existingUser != null)
                {
                    throw new BusinessException("The email address is already in use.");
                }

                User user = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                if (request.UserType == "doctor")
                {
                    await _userRepository.AddAsync(user);
                    Doctor doctor = _mapper.Map<Doctor>(request);
                    doctor.UserId = user.Id;
                    await _doctorService.AddDoctorAsync(doctor);

                    var operationClaimIds = new List<int> { 11, 22, 23, 28, 29, 30, 58, 59, 60 };
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
                else if (request.UserType == "patient")
                {
                    await _userRepository.AddAsync(user);
                    Patient patient = _mapper.Map<Patient>(request);
                    patient.UserId = user.Id;
                    await _patientService.AddPatientAsync(patient);

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
                else
                {
                    throw new BusinessException(UsersMessages.ValidUserType);
                }

                CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
                return response;
            }
        }
    }
}

