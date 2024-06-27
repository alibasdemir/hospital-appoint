using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Application.Features.Users.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackCommand : IRequest<CreateFeedbackResponse>
    {
		public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
        public int UserId { get; set; }
        public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;

			public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, IUserService userService)
			{
				_feedbackRepository = feedbackRepository;
				_mapper = mapper;
				_userService = userService;
			}

			public async Task<CreateFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
            {
                bool isUserExist = await _userService.UserValidationById(request.UserId);

                if (!isUserExist)
                {
                    throw new NotFoundException(UsersMessages.UserNotExists);
                }

                Feedback feedback = _mapper.Map<Feedback>(request);
                await _feedbackRepository.AddAsync(feedback);

                CreateFeedbackResponse response = _mapper.Map<CreateFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
