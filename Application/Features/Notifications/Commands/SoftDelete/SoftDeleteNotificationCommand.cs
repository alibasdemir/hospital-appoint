using Application.Features.Notifications.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Notifications.Constants.NotificationsOperationClaims;

namespace Application.Features.Notifications.Commands.SoftDelete
{
    public class SoftDeleteNotificationCommand : IRequest<SoftDeleteNotificationResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, NotificationsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteNotificationCommandHandler : IRequestHandler<SoftDeleteNotificationCommand, SoftDeleteNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public SoftDeleteNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteNotificationResponse> Handle(SoftDeleteNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(i => i.Id == request.Id);

                if (notification == null || notification.IsDeleted == true)
                {
                    throw new NotFoundException(NotificationsMessages.NotificationNotExists);
                }
                
                await _notificationRepository.SoftDeleteAsync(notification);

                SoftDeleteNotificationResponse response = _mapper.Map<SoftDeleteNotificationResponse>(notification);
                return response;
            }
        }
    }
}
