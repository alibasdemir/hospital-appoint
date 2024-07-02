using Application.Features.Doctors.Commands.Create;
using Application.Features.Doctors.Commands.Delete;
using Application.Features.Doctors.Commands.SoftDelete;
using Application.Features.Doctors.Commands.Update;
using Application.Features.Doctors.Queries.GetById;
using Application.Features.Doctors.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;

namespace Application.Features.Doctors.Profiles
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, CreateDoctorResponse>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorResponse>().ReverseMap();
            CreateMap<Doctor, DeleteDoctorCommand>().ReverseMap();
            CreateMap<Doctor, DeleteDoctorResponse>().ReverseMap();
            CreateMap<Doctor, SoftDeleteDoctorCommand>().ReverseMap();
            CreateMap<Doctor, SoftDeleteDoctorResponse>().ReverseMap();
            CreateMap<Doctor, GetByIdDoctorQuery>().ReverseMap();
            CreateMap<Doctor, GetByIdDoctorResponse>().ReverseMap();
            CreateMap<Doctor, GetListDoctorQuery>().ReverseMap();
            CreateMap<Doctor, GetListDoctorResponse>().ReverseMap();
            CreateMap<IPaginate<Doctor>, GetListResponse<GetListDoctorResponse>>().ReverseMap();
            CreateMap<User, CreateDoctorCommand>().ReverseMap();
        }
    }
}
