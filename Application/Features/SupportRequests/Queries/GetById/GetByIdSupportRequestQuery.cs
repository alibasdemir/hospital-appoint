using Application.Features.SupportRequests.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
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
            public GetByIdSupportRequestQueryHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdSupportRequestResponse> Handle(GetByIdSupportRequestQuery request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);

                if (supportRequest == null || supportRequest.IsDeleted == true) 
                {
                    throw new NotFoundException(SupportRequestsMessages.SupportRequestNotExists);
                }

                GetByIdSupportRequestResponse response = _mapper.Map<GetByIdSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
