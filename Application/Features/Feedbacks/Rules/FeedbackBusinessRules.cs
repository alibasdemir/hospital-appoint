using Application.Features.Feedbacks.Constants;
using Application.Repositories;
using Application.Services.UserService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Feedbacks.Rules
{
    public class FeedbackBusinessRules
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUserService _userService;

        public FeedbackBusinessRules(IFeedbackRepository feedbackRepository, IUserService userService)
        {
            _feedbackRepository = feedbackRepository;
            _userService = userService;
        }

        public async Task UserShouldBeExist(int id)
        {
            User user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new BusinessException(FeedbacksMessages.UserNotExists);
            }
        }

        public async Task FeedbackShouldBeExist(int id)
        {
            Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == id);
            if (feedback == null)
            {
                throw new BusinessException(FeedbacksMessages.FeedbackNotExists);
            }
        }

        public async Task FeedbackDeleteControl(int id)
        {
            Feedback? feedback = await _feedbackRepository.GetAsync(i => i.Id == id);
            if (feedback == null || feedback.IsDeleted == true)
            {
                throw new BusinessException(FeedbacksMessages.FeedbackNotExists);
            }
        }
    }
}
