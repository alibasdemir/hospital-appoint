using Application.Features.Feedbacks.Constants;
using Application.Features.Feedbacks.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Queries.GetById
{
    public class GetByIdFeedbackQuery : IRequest<GetByIdFeedbackResponse>
    {
        public int Id { get; set; }

        public class GetByIdFeedbackQueryHandler : IRequestHandler<GetByIdFeedbackQuery, GetByIdFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
            private readonly FeedbackBusinessRules _feedbackBusinessRules;

            public GetByIdFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper, FeedbackBusinessRules feedbackBusinessRules)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
                _feedbackBusinessRules = feedbackBusinessRules;
            }

            public async Task<GetByIdFeedbackResponse> Handle(GetByIdFeedbackQuery request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);

                await _feedbackBusinessRules.FeedbackDeleteControl(request.Id);

                GetByIdFeedbackResponse response = _mapper.Map<GetByIdFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
