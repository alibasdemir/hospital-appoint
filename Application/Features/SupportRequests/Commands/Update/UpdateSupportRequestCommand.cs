using Application.Features.SupportRequests.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.SupportRequests.Constants.SupportRequestsOperationClaims;

namespace Application.Features.SupportRequests.Commands.Update
{
    public class UpdateSupportRequestCommand : IRequest<UpdateSupportRequestResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, SupportRequestsOperationClaims.Update };
        public int Id { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public class UpdateSupportRequestCommandHandler : IRequestHandler<UpdateSupportRequestCommand, UpdateSupportRequestResponse>
        {
            private readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;

            public UpdateSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
            }

            public async Task<UpdateSupportRequestResponse> Handle(UpdateSupportRequestCommand request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);
                
                if (supportRequest == null || supportRequest.IsDeleted == true)
                {
                    throw new NotFoundException(SupportRequestsMessages.SupportRequestNotExists);
                }

                _mapper.Map(request, supportRequest);

                await _supportRequestRepository.UpdateAsync(supportRequest);
                UpdateSupportRequestResponse response = _mapper.Map<UpdateSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
