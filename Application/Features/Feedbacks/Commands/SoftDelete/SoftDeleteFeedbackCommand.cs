using Application.Features.Feedbacks.Constants;
using Application.Features.Feedbacks.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
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
            private readonly FeedbackBusinessRules _feedbackBusinessRules;

            public SoftDeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, FeedbackBusinessRules feedbackBusinessRules)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
                _feedbackBusinessRules = feedbackBusinessRules;
            }

            public async Task<SoftDeleteFeedbackResponse> Handle(SoftDeleteFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);

                await _feedbackBusinessRules.FeedbackDeleteControl(request.Id);

                await _feedbackRepository.SoftDeleteAsync(feedback);

                SoftDeleteFeedbackResponse response = _mapper.Map<SoftDeleteFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
