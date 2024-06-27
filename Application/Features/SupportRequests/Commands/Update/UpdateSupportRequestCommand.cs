using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.SupportRequests.Commands.Update
{
    public class UpdateSupportRequestCommand : IRequest<UpdateSupportRequestResponse>
    {
		public string FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
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
                SupportRequest supportRequest = _mapper.Map<SupportRequest>(request);
                
                await _supportRequestRepository.UpdateAsync(supportRequest);
                UpdateSupportRequestResponse response = _mapper.Map<UpdateSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
