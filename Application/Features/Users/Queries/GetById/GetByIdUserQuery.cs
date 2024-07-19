using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<GetByIdUserResponse>
    {
        public int Id { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i  => i.Id == request.Id);

                await _userBusinessRules.UserDeleteControl(request.Id);

                GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
                return response;
            }
        }
    }
}
