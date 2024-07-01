using Application.Features.Notifications.Constants;
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
        public NotificationType Type { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdateNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public UpdateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<UpdateNotificationResponse> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification notification = _mapper.Map<Notification>(request);

                await _notificationRepository.UpdateAsync(notification);
                UpdateNotificationResponse response = _mapper.Map<UpdateNotificationResponse>(notification);
                return response;
            }
        }
    }
}
