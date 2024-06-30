using Application.Features.Users.Constants;
using Application.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;


namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UsersOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IUserRepository _userRepository;

            public DeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                
                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                if (user == null)
                {
                    throw new ArgumentException("No such user found");
                }

                await _userRepository.DeleteAsync(user);

            }
        }
    }
}
