using Application.Features.Notifications.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
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
            private readonly NotificationBusinessRules _notificationBusinessRules;

            public GetByIdNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper, NotificationBusinessRules notificationBusinessRules)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _notificationBusinessRules = notificationBusinessRules;
            }

            public async Task<GetByIdNotificationResponse> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(i => i.Id == request.Id);

                await _notificationBusinessRules.NotificationDeleteControl(request.Id);

                GetByIdNotificationResponse response = _mapper.Map<GetByIdNotificationResponse>(notification);
                return response;
            }
        }
    }
}
