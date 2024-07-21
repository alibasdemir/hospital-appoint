using Application.Features.SupportRequests.Constants;
using Application.Features.SupportRequests.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.SupportRequests.Constants.SupportRequestsOperationClaims;

namespace Application.Features.SupportRequests.Commands.SoftDelete
{
    public class SoftDeleteSupportRequestCommand : IRequest<SoftDeleteSupportRequestResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, SupportRequestsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteSupportRequestCommandHandler : IRequestHandler<SoftDeleteSupportRequestCommand, SoftDeleteSupportRequestResponse>
        {
            private readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;
            private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

            public SoftDeleteSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
                _supportRequestBusinessRules = supportRequestBusinessRules;
            }

            public async Task<SoftDeleteSupportRequestResponse> Handle(SoftDeleteSupportRequestCommand request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);

                await _supportRequestBusinessRules.SupportRequestDeleteControl(request.Id);
                
                await _supportRequestRepository.SoftDeleteAsync(supportRequest);

                SoftDeleteSupportRequestResponse response = _mapper.Map<SoftDeleteSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
