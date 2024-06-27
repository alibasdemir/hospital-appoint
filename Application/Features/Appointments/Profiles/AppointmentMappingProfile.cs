using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Commands.Delete;
using Application.Features.Appointments.Commands.SoftDelete;
using Application.Features.Appointments.Commands.Update;
using AutoMapper;
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
            CreateMap<Appointment, SoftDeleteAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, SoftDeleteAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentResponse>().ReverseMap();
        }
    }
}
