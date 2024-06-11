using Application.Features.Users.Commands.Create;
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
        }
    }
}
