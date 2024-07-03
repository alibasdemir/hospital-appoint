using Application.Features.Auth.Commands.ChangePassword;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
            CreateMap<Patient, RegisterCommand>().ReverseMap();
            CreateMap<RegisterCommand, RegisterResponse>().ReverseMap();
            CreateMap<User, ChangePasswordCommand>().ReverseMap();
            CreateMap<User, ChangePasswordResponse>().ReverseMap();
            CreateMap<ChangePasswordCommand, ChangePasswordResponse>().ReverseMap();
        }
    }
}
