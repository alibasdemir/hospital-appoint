using Application.Features.Notifications.Constants;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Notifications.Rules
{
    public class NotificationBusinessRules
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationBusinessRules(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task NotificationShouldBeExist(int id)
        {
            Notification? notification = await _notificationRepository.GetAsync(i => i.Id == id);
            if (notification == null)
            {
                throw new BusinessException(NotificationsMessages.NotificationNotExists);
            }
        }

        public async Task NotificationDeleteControl(int id)
        {
            Notification? notification = await _notificationRepository.GetAsync(i => i.Id == id);
            if (notification == null || notification.IsDeleted == true)
            {
                throw new BusinessException(NotificationsMessages.NotificationNotExists);
            }
        }
    }
}
