using Application.Features.Departments.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Profiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, CreateDepartmentResponse>().ReverseMap();
        }
    }
}
