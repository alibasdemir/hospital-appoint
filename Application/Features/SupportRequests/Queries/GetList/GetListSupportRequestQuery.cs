using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.SupportRequests.Queries.GetList
{
    public class GetListSupportRequestQuery : IRequest<GetListResponse<GetListSupportRequestResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSupportRequestQueryHandler : IRequestHandler<GetListSupportRequestQuery, GetListResponse<GetListSupportRequestResponse>>
        {
            private readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;
            public GetListSupportRequestQueryHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListSupportRequestResponse>> Handle(GetListSupportRequestQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SupportRequest> supportRequest = await _supportRequestRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListSupportRequestResponse> response = _mapper.Map<GetListResponse<GetListSupportRequestResponse>>(supportRequest);
                return response;
            }
        }
    }
}
