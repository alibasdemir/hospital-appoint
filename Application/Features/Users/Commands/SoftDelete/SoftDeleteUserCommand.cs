using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.SoftDelete
{
    public class SoftDeleteUserCommand : IRequest
    {
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
