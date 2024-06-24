using Application.Features.DoctorSchedules.Commands.Create;
using Application.Features.DoctorSchedules.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.DoctorSchedules.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile() 
		{	
			CreateMap<DoctorAvailability, CreateDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, CreateDoctorAvailabilityResponse>().ReverseMap();
			
			CreateMap<DoctorAvailability, UpdateDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, UpdateDoctorAvailabilityResponse>().ReverseMap();
		}
	}
}
