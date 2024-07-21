using Application.Features.Feedbacks.Constants;
using Application.Features.Feedbacks.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Commands.Delete
{
    public class DeleteFeedbackCommand : IRequest<DeleteFeedbackResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, FeedbacksOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, DeleteFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
            private readonly FeedbackBusinessRules _feedbackBusinessRules;
            public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, FeedbackBusinessRules feedbackBusinessRules)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
                _feedbackBusinessRules = feedbackBusinessRules;
            }

            public async Task<DeleteFeedbackResponse> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);

                await _feedbackBusinessRules.FeedbackShouldBeExist(request.Id);

                await _feedbackRepository.DeleteAsync(feedback);
                DeleteFeedbackResponse response = _mapper.Map<DeleteFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
