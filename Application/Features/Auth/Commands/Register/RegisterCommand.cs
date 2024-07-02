using Application.Repositories;
using Application.Services.PatientService;
using AutoMapper;
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

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, IPatientService petientService)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _petientService = petientService;
            }

            public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
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

                RegisterResponse response = _mapper.Map<RegisterResponse>(request);
                return response;
            }
        }
    }
}
