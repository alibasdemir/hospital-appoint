using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Commands.Delete;
using Application.Features.Notifications.Commands.SoftDelete;
using Application.Features.Notifications.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Notifications.Profiles
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
			CreateMap<Notification, CreateNotificationCommand>().ReverseMap();
			CreateMap<Notification, CreateNotificationResponse>().ReverseMap();
			
			CreateMap<Notification, UpdateNotificationCommand>().ReverseMap();
			CreateMap<Notification, UpdateNotificationResponse>().ReverseMap();

			CreateMap<Notification, DeleteNotificationCommand>().ReverseMap();
			CreateMap<Notification, DeleteNotificationResponse>().ReverseMap();

			CreateMap<Notification, SoftDeleteNotificationCommand>().ReverseMap();
			CreateMap<Notification, SoftDeleteNotificationResponse>().ReverseMap();
		}
    }
}
