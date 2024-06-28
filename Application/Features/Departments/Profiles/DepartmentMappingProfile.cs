using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.SoftDelete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
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
            CreateMap<Department, DeleteDepartmentResponse>().ReverseMap();
            CreateMap<Department, SoftDeleteDepartmentCommand>().ReverseMap();
            CreateMap<Department, SoftDeleteDepartmentResponse>().ReverseMap();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();
            CreateMap<Department, UpdateDepartmentResponse>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentQuery>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentResponse>().ReverseMap();
            CreateMap<Department, GetListDepartmentQuery>().ReverseMap();
            CreateMap<Department, GetListDepartmentResponse>().ReverseMap();
            CreateMap<IPaginate<Department>, GetListResponse<GetListDepartmentResponse>>().ReverseMap();
        }
    }
}
