using Application.Features.AdminActions.Commands.Create;
using Application.Features.AdminActions.Commands.Update;
using Application.Features.AdminActions.Queries.GetById;
using Application.Features.AdminActions.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AdminActions.Profiles
{
    public class AdminActionMappingProfile : Profile
    {
        public AdminActionMappingProfile()
        {
            CreateMap<AdminAction, CreateAdminActionCommand>().ReverseMap();
            CreateMap<AdminAction, CreateAdminActionResponse>().ReverseMap();
            CreateMap<AdminAction, UpdateAdminActionCommand>().ReverseMap();
            CreateMap<AdminAction, UpdateAdminActionResponse>().ReverseMap();
            CreateMap<AdminAction, GetListAdminActionQuery>().ReverseMap();
            CreateMap<AdminAction, GetListAdminActionResponse>().ReverseMap();
            CreateMap<AdminAction, GetByIdAdminActionQuery>().ReverseMap();
            CreateMap<AdminAction, GetByIdAdminActionResponse>().ReverseMap();
        }
    }
}
