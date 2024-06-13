using Application.Features.Admins.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Profiles
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<Admin, CreateAdminCommand>().ReverseMap();
            CreateMap<Admin, CreateAdminResponse>().ReverseMap();
        }
    }
}
