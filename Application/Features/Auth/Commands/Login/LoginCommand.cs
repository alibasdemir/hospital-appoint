using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Hashing;
using Core.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private IUserRepository _userRepository;
            private ITokenHelper _tokenHelper;

            public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
               User? user = await _userRepository.GetAsync(i => i.Email == request.Email);

                if (user is null)
                {
                    throw new BusinessException("Login Failed");
                }

                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

                if (!isPasswordMatch)
                {
                    throw new BusinessException("Login Failed");
                }

               return _tokenHelper.CreateToken(user);
            }
        }
    }
}
