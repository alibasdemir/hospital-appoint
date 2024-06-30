using Application.Features.Notifications.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Notifications.Constants.NotificationsOperationClaims;

namespace Application.Features.Notifications.Queries.GetById
{
    public class GetByIdNotificationQuery : IRequest<GetByIdNotificationResponse>, ISecuredRequest
    {
        public string[] RequiredRoles => new[] { Admin, Read };
        public int Id { get; set; }

        public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQuery, GetByIdNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            public GetByIdNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdNotificationResponse> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(i => i.Id == request.Id);

                if (notification == null || notification.IsDeleted == true) 
                {
                    throw new NotFoundException(NotificationsMessages.NotificationExists);
                }

                GetByIdNotificationResponse response = _mapper.Map<GetByIdNotificationResponse>(notification);
                return response;
            }
        }
    }
}
