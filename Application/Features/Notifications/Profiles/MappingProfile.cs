using Application.Features.Notifications.Commands.Create;
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
		}
    }
}
