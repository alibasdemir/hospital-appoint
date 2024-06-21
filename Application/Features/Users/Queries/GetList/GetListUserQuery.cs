using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<GetListResponse<GetListUserResponse>>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] RequiredRoles => ["User.GetList"];

        public class GetListQueryHandler : IRequestHandler<GetListUserQuery, GetListResponse<GetListUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetListUserResponse>>(users);
                
                return response;
            }
        }
    }
}
