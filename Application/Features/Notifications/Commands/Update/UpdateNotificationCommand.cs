using Application.Features.Notifications.Constants;
using Application.Features.Notifications.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using static Application.Features.Notifications.Constants.NotificationsOperationClaims;

namespace Application.Features.Notifications.Commands.Update
{
    public class UpdateNotificationCommand : IRequest<UpdateNotificationResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, NotificationsOperationClaims.Update };
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
		public string Message { get; set; }
		public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdateNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            private readonly NotificationBusinessRules _notificationBusinessRules;

            public UpdateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper, NotificationBusinessRules notificationBusinessRules)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _notificationBusinessRules = notificationBusinessRules;
            }

            public async Task<UpdateNotificationResponse> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(i => i.Id == request.Id);

                await _notificationBusinessRules.NotificationDeleteControl(request.Id);

                _mapper.Map(request, notification);

                await _notificationRepository.UpdateAsync(notification);
                UpdateNotificationResponse response = _mapper.Map<UpdateNotificationResponse>(notification);
                return response;
            }
        }
    }
}
