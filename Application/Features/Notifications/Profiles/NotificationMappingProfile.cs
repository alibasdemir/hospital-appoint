using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Commands.Delete;
using Application.Features.Notifications.Commands.SoftDelete;
using Application.Features.Notifications.Commands.Update;
using Application.Features.Notifications.Queries.GetById;
using Application.Features.Notifications.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;

namespace Application.Features.Notifications.Profiles
{
	public class NotificationMappingProfile : Profile
	{
        public NotificationMappingProfile()
        {
			CreateMap<Notification, CreateNotificationCommand>().ReverseMap();
			CreateMap<Notification, CreateNotificationResponse>().ReverseMap();
			CreateMap<Notification, UpdateNotificationCommand>().ReverseMap();
			CreateMap<Notification, UpdateNotificationResponse>().ReverseMap();
			CreateMap<Notification, DeleteNotificationCommand>().ReverseMap();
			CreateMap<Notification, DeleteNotificationResponse>().ReverseMap();
			CreateMap<Notification, SoftDeleteNotificationCommand>().ReverseMap();
			CreateMap<Notification, SoftDeleteNotificationResponse>().ReverseMap();
			CreateMap<Notification, GetByIdNotificationQuery>().ReverseMap();
			CreateMap<Notification, GetByIdNotificationResponse>().ReverseMap();
			CreateMap<Notification, GetListNotificationQuery>().ReverseMap();
			CreateMap<Notification, GetListNotificationResponse>().ReverseMap();
			CreateMap<IPaginate<Notification>, GetListResponse<GetListNotificationResponse>>().ReverseMap();
		}
    }
}
