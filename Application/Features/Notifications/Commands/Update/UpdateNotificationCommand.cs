using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Notifications.Commands.Update
{
    public class UpdateNotificationCommand : IRequest<UpdateNotificationResponse>
    {
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
