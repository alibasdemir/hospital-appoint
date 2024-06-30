using Application.Features.Feedbacks.Constants;
using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Commands.Update
{
    public class UpdateFeedbackCommand : IRequest<UpdateFeedbackResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, FeedbacksOperationClaims.Update };
        public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
		public int UserId { get; set; }
		public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, UpdateFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
			private readonly IUserService _userService;

			public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, IUserService userService)
			{
				_feedbackRepository = feedbackRepository;
				_mapper = mapper;
				_userService = userService;
			}

			public async Task<UpdateFeedbackResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
            {
				bool isUserExist = await _userService.UserValidationById(request.UserId);

				if (!isUserExist)
				{
					throw new NotFoundException(UsersMessages.UserNotExists);
				}

				Feedback feedback = _mapper.Map<Feedback>(request);
				await _feedbackRepository.AddAsync(feedback);

				UpdateFeedbackResponse response = _mapper.Map<UpdateFeedbackResponse>(feedback);
				return response;
			}
        }
    }
}
