using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.SoftDelete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Users.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserCommand>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender, true)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => Enum.Parse<City>(src.City, true)));
            CreateMap<User, CreateUserResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap();
            CreateMap<User, UpdateUserCommand>()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
               .ReverseMap()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender, true)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => Enum.Parse<City>(src.City, true)));
            CreateMap<User, UpdateUserResponse>()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
               .ReverseMap();
            CreateMap<User, GetListUserQuery>().ReverseMap();
            CreateMap<User, GetListUserResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap();
            CreateMap<IPaginate<User>, GetListResponse<GetListUserResponse>>().ReverseMap();
            CreateMap<User, GetByIdUserQuery>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap();

            CreateMap<Patient, CreateUserCommand>().ReverseMap();
            CreateMap<Doctor, CreateUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserReponse>().ReverseMap();
            CreateMap<User, SoftDeleteUserCommand>().ReverseMap();
            CreateMap<User,SoftDeleteUserResponse>().ReverseMap();
        }
    }
}
