using Application.Features.OperationClaims.Commands.Create;
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
        }
    }
}
