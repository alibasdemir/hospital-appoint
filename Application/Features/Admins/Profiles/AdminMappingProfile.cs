using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Update;
using Application.Features.Admins.Queries.GetById;
using Application.Features.Admins.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Admins.Profiles
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<Admin, CreateAdminCommand>().ReverseMap();
            CreateMap<Admin, CreateAdminResponse>().ReverseMap();
            CreateMap<Admin, UpdateAdminCommand>().ReverseMap();
            CreateMap<Admin, UpdateAdminResponse>().ReverseMap();
            CreateMap<Admin, GetListAdminQuery>().ReverseMap();
            CreateMap<Admin, GetListAdminResponse>().ReverseMap();
            CreateMap<Admin, GetByIdAdminQuery>().ReverseMap();
            CreateMap<Admin, GetByIdAdminResponse>()
            .ForMember(dest => dest.AdminActions, opt => opt.MapFrom(src => src.AdminActions.Select(aa => new AdminAction { Id = aa.Id }).ToList()));
        }
    }
}
