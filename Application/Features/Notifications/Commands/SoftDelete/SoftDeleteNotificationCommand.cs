using Application.Features.Notifications.Constants;
using Application.Features.Notifications.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
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
            private readonly NotificationBusinessRules _notificationBusinessRules;

            public SoftDeleteNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper, NotificationBusinessRules notificationBusinessRules)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _notificationBusinessRules = notificationBusinessRules;
            }

            public async Task<SoftDeleteNotificationResponse> Handle(SoftDeleteNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(i => i.Id == request.Id);

                await _notificationBusinessRules.NotificationDeleteControl(request.Id);
                
                await _notificationRepository.SoftDeleteAsync(notification);

                SoftDeleteNotificationResponse response = _mapper.Map<SoftDeleteNotificationResponse>(notification);
                return response;
            }
        }
    }
}
