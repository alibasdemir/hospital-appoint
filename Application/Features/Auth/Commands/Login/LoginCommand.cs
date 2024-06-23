using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Core.Hashing;
using Core.JWT;
using Core.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            private IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
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

                IPaginate<UserOperationClaim> userOperationClaimsPaginate = await _userOperationClaimRepository.GetListAsync(i => i.BaseUserId == user.Id, include: i => i.Include(i => i.OperationClaim));
                List<UserOperationClaim> userOperationClaims = userOperationClaimsPaginate.Items.ToList();

                return _tokenHelper.CreateToken(user, userOperationClaims.Select(i => i.OperationClaim).ToList());
            }
        }
    }
}
