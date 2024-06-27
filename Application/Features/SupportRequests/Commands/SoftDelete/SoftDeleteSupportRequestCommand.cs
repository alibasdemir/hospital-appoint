using Application.Features.SupportRequests.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.SupportRequests.Commands.SoftDelete
{
    public class SoftDeleteSupportRequestCommand : IRequest<SoftDeleteSupportRequestResponse>
    {

        public int Id { get; set; }


        public class SoftDeleteSupportRequestCommandHandler : IRequestHandler<SoftDeleteSupportRequestCommand, SoftDeleteSupportRequestResponse>
        {
            private readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;

            public SoftDeleteSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteSupportRequestResponse> Handle(SoftDeleteSupportRequestCommand request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);

                if (supportRequest == null)
                {
                    throw new NotFoundException(SupportRequestsMessages.SupportRequestNotExists);
                }
                
                await _supportRequestRepository.SoftDeleteAsync(supportRequest);

                SoftDeleteSupportRequestResponse response = _mapper.Map<SoftDeleteSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
