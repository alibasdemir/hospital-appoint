﻿using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Queries.GetList
{
    public class GetListNotificationQuery : IRequest<GetListResponse<GetListNotificationResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, GetListResponse<GetListNotificationResponse>>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public GetListNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListNotificationResponse>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Notification> notification = await _notificationRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListNotificationResponse> response = _mapper.Map<GetListResponse<GetListNotificationResponse>>(notification);
                return response;
            }
        }
    }
}
