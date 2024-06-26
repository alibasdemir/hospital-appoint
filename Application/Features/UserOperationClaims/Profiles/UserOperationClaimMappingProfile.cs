﻿using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.SoftDelete;
using Application.Features.UserOperationClaims.Commands.Update;
using AutoMapper;
using Core.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class UserOperationClaimMappingProfile : Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, SoftDeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, SoftDeleteUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimResponse>().ReverseMap();
        }
    }
}
