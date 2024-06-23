using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.SoftDelete;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Departments.Profiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, CreateDepartmentResponse>().ReverseMap();
            CreateMap<Department, DeleteDepartmentCommand>().ReverseMap();
            CreateMap<Department, SoftDeleteDepartmentCommand>().ReverseMap();
            CreateMap<Department, SoftDeleteDepartmentResponse>().ReverseMap();
        }
    }
}
