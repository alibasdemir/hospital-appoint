using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.AdminActions.Queries.GetById
{
    public class GetByIdAdminActionQuery : IRequest<GetByIdAdminActionResponse>
    {
        public int Id { get; set; }

        public class GetByIdAdminActionQueryHandler : IRequestHandler<GetByIdAdminActionQuery, GetByIdAdminActionResponse>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public GetByIdAdminActionQueryHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAdminActionResponse> Handle(GetByIdAdminActionQuery request, CancellationToken cancellationToken)
            {
                AdminAction? adminAction = await _adminActionRepository.GetAsync(i => i.Id == request.Id);
                if (adminAction == null)
                {
                    throw new Exception("No such Admin Action found");
                }

                GetByIdAdminActionResponse response = _mapper.Map<GetByIdAdminActionResponse>(adminAction);
                return response;
            }
        }
    }
}
