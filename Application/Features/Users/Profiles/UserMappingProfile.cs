using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserResponse>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserResponse>().ReverseMap();
            CreateMap<User, GetListUserQuery>().ReverseMap();
            CreateMap<User, GetListUserResponse>().ReverseMap();
            CreateMap<User, GetByIdUserQuery>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>().ReverseMap();
        }
    }
}
