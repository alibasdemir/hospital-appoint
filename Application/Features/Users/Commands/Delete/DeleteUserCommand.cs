using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;


namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserReponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UsersOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserReponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<DeleteUserReponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                
                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                await _userBusinessRules.UserShouldBeExist(request.Id);

                await _userRepository.DeleteAsync(user);
                DeleteUserReponse response = _mapper.Map<DeleteUserReponse>(user);
                return response;

            }
        }
    }
}
