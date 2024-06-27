using Application.Features.Patients.Commands.Delete;
using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using Application.Features.Patients.Commands.SoftDelete;

namespace Application.Features.Patients.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, CreatePatientResponse>().ReverseMap();

			CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
			CreateMap<Patient, UpdatePatientResponse>().ReverseMap();

			CreateMap<Patient, DeletePatientCommand>().ReverseMap();
			CreateMap<Patient, DeletePatientResponse>().ReverseMap();

			CreateMap<Patient, SoftDeletePatientCommand>().ReverseMap();
			CreateMap<Patient, SoftDeletePatientResponse>().ReverseMap();
		}
    }
}
