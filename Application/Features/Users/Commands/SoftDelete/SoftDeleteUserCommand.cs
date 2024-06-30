using Application.Features.Users.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.SoftDelete
{
    public class SoftDeleteUserCommand : IRequest<SoftDeleteUserResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UsersOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand, SoftDeleteUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public SoftDeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteUserResponse> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                if (user == null || user.IsDeleted == true)
                {
                    throw new NotFoundException(UsersMessages.UserNotExists);
                }

                await _userRepository.SoftDeleteAsync(user);
                SoftDeleteUserResponse response = _mapper.Map<SoftDeleteUserResponse>(user);
                return response;
            }
        }
    }
}
