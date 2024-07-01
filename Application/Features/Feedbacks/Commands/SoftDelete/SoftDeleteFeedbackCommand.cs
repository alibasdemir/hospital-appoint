using Application.Features.Feedbacks.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Commands.SoftDelete
{
    public class SoftDeleteFeedbackCommand : IRequest<SoftDeleteFeedbackResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, FeedbacksOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteFeedbackCommandHandler : IRequestHandler<SoftDeleteFeedbackCommand, SoftDeleteFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;

            public SoftDeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteFeedbackResponse> Handle(SoftDeleteFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);

                if (feedback == null || feedback.IsDeleted == true)
                {
                    throw new NotFoundException(FeedbacksMessages.FeedbackNotExists);
                }
                
                await _feedbackRepository.SoftDeleteAsync(feedback);

                SoftDeleteFeedbackResponse response = _mapper.Map<SoftDeleteFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
