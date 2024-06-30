using Application.Features.Users.Constants;
using Application.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.SoftDelete
{
    public class SoftDeleteUserCommand : IRequest, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UsersOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand>
        {
            private readonly IUserRepository _userRepository;

            public SoftDeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                if (user == null)
                {
                    throw new ArgumentException("No such user found");
                }

                await _userRepository.SoftDeleteAsync(user);
            }
        }
    }
}
