using Application.Features.Feedbacks.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

            public GetByIdFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdFeedbackResponse> Handle(GetByIdFeedbackQuery request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);
                
                if (feedback == null || feedback.IsDeleted == true)
                {
                    throw new NotFoundException(FeedbacksMessages.FeedbackNotExists);
                }

                GetByIdFeedbackResponse response = _mapper.Map<GetByIdFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
