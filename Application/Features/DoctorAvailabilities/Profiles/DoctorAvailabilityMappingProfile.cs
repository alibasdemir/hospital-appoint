using Application.Features.DoctorAvailabilities.Commands.Create;
using Application.Features.DoctorAvailabilities.Commands.Delete;
using Application.Features.DoctorAvailabilities.Commands.SoftDelete;
using Application.Features.DoctorAvailabilities.Commands.Update;
using Application.Features.DoctorAvailabilities.Queries.GetById;
using Application.Features.DoctorAvailabilities.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;

namespace Application.Features.DoctorAvailabilities.Profiles
{
    public class DoctorAvailabilityMappingProfile : Profile
	{
		public DoctorAvailabilityMappingProfile() 
		{	
			CreateMap<DoctorAvailability, CreateDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, CreateDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, UpdateDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, UpdateDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, DeleteDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, DeleteDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, SoftDeleteDoctorAvailabilityCommand>().ReverseMap();
			CreateMap<DoctorAvailability, SoftDeleteDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, GetByIdDoctorAvailabilityQuery>().ReverseMap();
			CreateMap<DoctorAvailability, GetByIdDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<DoctorAvailability, GetListDoctorAvailabilityQuery>().ReverseMap();
			CreateMap<DoctorAvailability, GetListDoctorAvailabilityResponse>().ReverseMap();
			CreateMap<IPaginate<DoctorAvailability>, GetListResponse<GetListDoctorAvailabilityResponse>>().ReverseMap();
        }
	}
}
