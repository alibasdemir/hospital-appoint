using Application.Features.Feedbacks.Constants;
using Application.Features.Feedbacks.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Commands.Update
{
    public class UpdateFeedbackCommand : IRequest<UpdateFeedbackResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, FeedbacksOperationClaims.Update };
		public int Id { get; set; }
        public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
		public int UserId { get; set; }
		public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, UpdateFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
			private readonly FeedbackBusinessRules _feedbackBusinessRules;

            public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, FeedbackBusinessRules feedbackBusinessRules)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
                _feedbackBusinessRules = feedbackBusinessRules;
            }

            public async Task<UpdateFeedbackResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
            {
				Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);

                await _feedbackBusinessRules.FeedbackDeleteControl(request.Id);

				_mapper.Map(request, feedback);

				await _feedbackRepository.UpdateAsync(feedback);

				UpdateFeedbackResponse response = _mapper.Map<UpdateFeedbackResponse>(feedback);
				return response;
			}
        }
    }
}
