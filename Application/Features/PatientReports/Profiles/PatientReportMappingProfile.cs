using Application.Features.PatientReports.Commands.Delete;
using Application.Features.PatientReports.Commands.SoftDelete;
using Application.Features.PatientReports.Commands.Create;
using Application.Features.PatientReports.Commands.Update;
using AutoMapper;
using Domain.Entities;
using Application.Features.PatientReports.Queries.GetById;
using Application.Features.PatientReports.Queries.GetList;
using Core.Paging;
using Core.Responses;

namespace Application.Features.PatientReports.Profiles
{
    public class PatientReportMappingProfile : Profile
	{
		public PatientReportMappingProfile() 
		{	
			CreateMap<PatientReport, CreatePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, CreatePatientReportResponse>().ReverseMap();
			CreateMap<PatientReport, UpdatePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, UpdatePatientReportResponse>().ReverseMap();
			CreateMap<PatientReport, DeletePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, DeletePatientReportResponse>().ReverseMap();
			CreateMap<PatientReport, SoftDeletePatientReportCommand>().ReverseMap();
			CreateMap<PatientReport, SoftDeletePatientReportResponse>().ReverseMap();
			CreateMap<PatientReport, GetByIdPatientReportQuery>().ReverseMap();
			CreateMap<PatientReport, GetByIdPatientReportResponse>().ReverseMap();
			CreateMap<PatientReport, GetListPatientReportQuery>().ReverseMap();
			CreateMap<PatientReport, GetListPatientReportResponse>().ReverseMap();
			CreateMap<IPaginate<PatientReport>, GetListResponse<GetListPatientReportResponse>>().ReverseMap();
		}
	}
}
