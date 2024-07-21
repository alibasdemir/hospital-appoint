using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;
using Application.Features.Feedbacks.Rules;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackCommand : IRequest<CreateFeedbackResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, Write, Add };
        public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
        public int UserId { get; set; }
        public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
            private readonly FeedbackBusinessRules _feedbackBusinessRules;

            public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, FeedbackBusinessRules feedbackBusinessRules)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
                _feedbackBusinessRules = feedbackBusinessRules;
            }

            public async Task<CreateFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
            {
                await _feedbackBusinessRules.UserShouldBeExist(request.UserId);

                Feedback feedback = _mapper.Map<Feedback>(request);
                await _feedbackRepository.AddAsync(feedback);

                CreateFeedbackResponse response = _mapper.Map<CreateFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
