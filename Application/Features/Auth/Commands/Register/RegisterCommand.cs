using Application.Repositories;
using Application.Services.OperationClaimService;
using Application.Services.PatientService;
using Application.Services.UserOperationClaimService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Core.Hashing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IPatientService _petientService;
            private readonly IUserOperationClaimService _userOperationClaimService;
            private readonly IOperationClaimService _operationClaimService;

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, IPatientService petientService, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _petientService = petientService;
                _userOperationClaimService = userOperationClaimService;
                _operationClaimService = operationClaimService;
            }

            public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
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
                user.UserType = "patient";
                
                await _userRepository.AddAsync(user);

                Patient patient = _mapper.Map<Patient>(request);
                patient.UserId = user.Id;
                await _petientService.AddPatientAsync(patient);


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

                RegisterResponse response = _mapper.Map<RegisterResponse>(request);
                return response;
            }
        }
    }
}
