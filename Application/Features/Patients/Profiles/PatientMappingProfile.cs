using Application.Features.Patients.Commands.Delete;
using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using Application.Features.Patients.Commands.SoftDelete;
using Application.Features.Patients.Queries.GetById;
using Application.Features.Patients.Queries.GetList;
using Core.Paging;
using Core.Responses;

namespace Application.Features.Patients.Profiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, CreatePatientResponse>().ReverseMap();
			CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
			CreateMap<Patient, UpdatePatientResponse>().ReverseMap();
			CreateMap<Patient, DeletePatientCommand>().ReverseMap();
			CreateMap<Patient, DeletePatientResponse>().ReverseMap();
			CreateMap<Patient, SoftDeletePatientCommand>().ReverseMap();
			CreateMap<Patient, SoftDeletePatientResponse>().ReverseMap();
            CreateMap<Patient, GetByIdPatientQuery>().ReverseMap();
            CreateMap<Patient, GetByIdPatientResponse>().ReverseMap();
            CreateMap<Patient, GetListPatientQuery>().ReverseMap();
            CreateMap<Patient, GetListPatientResponse>().ReverseMap();
            CreateMap<IPaginate<Patient>, GetListResponse<GetListPatientResponse>>().ReverseMap();
		}
    }
}
