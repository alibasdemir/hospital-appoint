using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Notifications.Commands.Create
{
    public class CreateNotificationCommand : IRequest<CreateNotificationResponse>
    {
		public NotificationType Type { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<CreateNotificationResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification notification = _mapper.Map<Notification>(request);

                await _notificationRepository.AddAsync(notification);
                CreateNotificationResponse response = _mapper.Map<CreateNotificationResponse>(notification);
                return response;
            }
        }
    }
}
