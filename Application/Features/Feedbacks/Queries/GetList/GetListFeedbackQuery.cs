using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Queries.GetList
{
    public class GetListFeedbackQuery : IRequest<GetListResponse<GetListFeedbackResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, GetListResponse<GetListFeedbackResponse>>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
            public GetListFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListFeedbackResponse>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Feedback> feedback = await _feedbackRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListFeedbackResponse> response = _mapper.Map<GetListResponse<GetListFeedbackResponse>>(feedback);
                return response;
            }
        }
    }
}
