using Application.Features.SupportRequests.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SupportRequests.Queries.GetById
{
    public class GetByIdSupportRequestQuery : IRequest<GetByIdSupportRequestResponse>
    {
        public int Id { get; set; }

        public class GetByIdSupportRequestQueryHandler : IRequestHandler<GetByIdSupportRequestQuery, GetByIdSupportRequestResponse>
        {
            private readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;
            private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

            public GetByIdSupportRequestQueryHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
                _supportRequestBusinessRules = supportRequestBusinessRules;
            }

            public async Task<GetByIdSupportRequestResponse> Handle(GetByIdSupportRequestQuery request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);

                await _supportRequestBusinessRules.SupportRequestDeleteControl(request.Id);

                GetByIdSupportRequestResponse response = _mapper.Map<GetByIdSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
