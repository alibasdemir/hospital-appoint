using Application.Features.Feedbacks.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
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
            public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<DeleteFeedbackResponse> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == request.Id);

                if (feedback == null)
                {
                    throw new NotFoundException(FeedbacksMessages.FeedbackNotExists);
                }

                await _feedbackRepository.DeleteAsync(feedback);
                DeleteFeedbackResponse response = _mapper.Map<DeleteFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
