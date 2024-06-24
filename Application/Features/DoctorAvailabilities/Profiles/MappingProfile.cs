using Application.Features.DoctorAvailabilities.Commands.Create;
using Application.Features.DoctorAvailabilities.Commands.Delete;
using Application.Features.DoctorAvailabilities.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.DoctorAvailabilities.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile() 
		{	
			CreateMap<DoctorAvailability, CreateDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, CreateDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, UpdateDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, UpdateDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, DeleteDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, DeleteDoctorAvailabilityResponse>().ReverseMap();
        }
	}
}
