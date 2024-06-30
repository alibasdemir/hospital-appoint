using Application.Features.Notifications.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Notifications.Constants.NotificationsOperationClaims;

namespace Application.Features.Notifications.Commands.Delete
{
    public class DeleteNotificationCommand : IRequest<DeleteNotificationResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, NotificationsOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, DeleteNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            public DeleteNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<DeleteNotificationResponse> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(i => i.Id == request.Id);

                if (notification == null)
                {
                    throw new NotFoundException(NotificationsMessages.NotificationNotExists);
                }

                await _notificationRepository.DeleteAsync(notification);
                DeleteNotificationResponse response = _mapper.Map<DeleteNotificationResponse>(notification);
                return response;
            }
        }
    }
}
