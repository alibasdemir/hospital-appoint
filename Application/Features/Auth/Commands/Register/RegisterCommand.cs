using Application.Features.Auth.Rules;
using Application.Repositories;
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
        public string UserType { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {

                await _authBusinessRules.UserEmailAlreadyUsed(request.Email);

                User user = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _authBusinessRules.AddUserWithUserType(user, request.UserType);

                await _authBusinessRules.AssignClaimsToUserBasedOnTypeAsync(user, request.UserType);

                RegisterResponse response = _mapper.Map<RegisterResponse>(request);
                return response;
            }
        }
    }
}
