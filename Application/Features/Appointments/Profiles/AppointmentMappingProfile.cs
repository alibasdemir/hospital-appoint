using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Commands.Delete;
using Application.Features.Appointments.Commands.SoftDelete;
using Application.Features.Appointments.Commands.Update;
using Application.Features.Appointments.Queries.GetById;
using Application.Features.Appointments.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;

namespace Application.Features.Appointments.Profiles
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, DeleteAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, DeleteAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, SoftDeleteAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, SoftDeleteAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, GetByIdAppointmentQuery>().ReverseMap();
            CreateMap<Appointment, GetByIdAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, GetListAppointmentQuery>().ReverseMap();
            CreateMap<Appointment, GetListAppointmentResponse>().ReverseMap();
            CreateMap<IPaginate<Appointment>, GetListResponse<GetListAppointmentResponse>>().ReverseMap();
        }
    }
}
