using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<List<GetListUserResponse>>
    {
        //public int Page { get; set; }
        //public int PageSize { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetListUserQuery, List<GetListUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                List<User> users = await _userRepository.GetListAsync();

                List<GetListUserResponse> response = _mapper.Map<List<GetListUserResponse>>(users);
                return response;
            }
        }
    }
}
