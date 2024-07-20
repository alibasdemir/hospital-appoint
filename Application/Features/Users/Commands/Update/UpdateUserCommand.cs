using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UsersOperationClaims.Update };
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                await _userBusinessRules.UserShouldBeExist(request.Id);

                await _userBusinessRules.UserEmailCanBeUpdated(request.Id, request.Email);

                _mapper.Map(request, user);

                await _userRepository.UpdateAsync(user);

                UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);
                return response;
            }
        }
    }
}
