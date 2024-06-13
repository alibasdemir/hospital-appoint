using Application.Features.AdminActions.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Profiles
{
    public class AdminActionMappingProfile : Profile
    {
        public AdminActionMappingProfile()
        {
            CreateMap<AdminAction, CreateAdminActionCommand>().ReverseMap();
            CreateMap<AdminAction, CreateAdminActionResponse>().ReverseMap();
        }
    }
}
