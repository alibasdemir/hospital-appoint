using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Update
{
    public class UpdateFeedbackCommand : IRequest<UpdateFeedbackResponse>
    {
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
