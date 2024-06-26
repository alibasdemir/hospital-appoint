using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Commands.Delete;
using Application.Features.OperationClaims.Commands.SoftDelete;
using AutoMapper;
using Core.Entities;

namespace Application.Features.OperationClaims.Profiles
{
    public class OperationClaimMappingProfile : Profile
    {
        public OperationClaimMappingProfile()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, SoftDeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, SoftDeleteOperationClaimResponse>().ReverseMap();
        }
    }
}
