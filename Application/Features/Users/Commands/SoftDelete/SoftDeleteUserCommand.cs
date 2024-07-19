using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
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
            private readonly UserBusinessRules _userBusinessRules;

            public SoftDeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<SoftDeleteUserResponse> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                await _userBusinessRules.UserDeleteControl(request.Id);

                await _userRepository.SoftDeleteAsync(user);

                await _userBusinessRules.DoctorOrPatientDelete(request.Id);
                SoftDeleteUserResponse response = _mapper.Map<SoftDeleteUserResponse>(user);
                return response;
            }
        }
    }
}
