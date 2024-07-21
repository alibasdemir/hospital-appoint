using Application.Features.SupportRequests.Constants;
using Application.Features.SupportRequests.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.SupportRequests.Constants.SupportRequestsOperationClaims;

namespace Application.Features.SupportRequests.Commands.Delete
{
    public class DeleteSupportRequestCommand : IRequest<DeleteSupportRequestResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, SupportRequestsOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteSupportRequestCommandHandler : IRequestHandler<DeleteSupportRequestCommand, DeleteSupportRequestResponse>
        {
            public readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;
            private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
            public DeleteSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
                _supportRequestBusinessRules = supportRequestBusinessRules;
            }

            public async Task<DeleteSupportRequestResponse> Handle(DeleteSupportRequestCommand request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);

                await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.Id);

                await _supportRequestRepository.DeleteAsync(supportRequest);
                DeleteSupportRequestResponse response = _mapper.Map<DeleteSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
