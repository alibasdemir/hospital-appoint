using Application.Features.PatientReports.Commands.Delete;
using Application.Features.PatientReports.Commands.SoftDelete;
using Application.Features.PatientReports.Commands.Create;
using Application.Features.PatientReports.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.PatientReports.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile() 
		{	
			CreateMap<PatientReport, CreatePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, CreatePatientReportResponse>().ReverseMap();
			
			CreateMap<PatientReport, UpdatePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, UpdatePatientReportResponse>().ReverseMap();

			CreateMap<PatientReport, DeletePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, DeletePatientReportResponse>().ReverseMap();

			CreateMap<PatientReport, SoftDeletePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, SoftDeletePatientReportResponse>().ReverseMap();
		}
	}
}
