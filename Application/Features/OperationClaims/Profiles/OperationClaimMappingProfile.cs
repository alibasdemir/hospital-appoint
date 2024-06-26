using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Commands.Delete;
using Application.Features.OperationClaims.Commands.SoftDelete;
using Application.Features.OperationClaims.Commands.Update;
using Application.Features.OperationClaims.Queries.GetById;
using Application.Features.OperationClaims.Queries.GetList;
using AutoMapper;
using Core.Entities;
using Core.Paging;
using Core.Responses;

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
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, GetByIdOperationClaimQuery>().ReverseMap();
            CreateMap<OperationClaim, GetByIdOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimQuery>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, GetListResponse<GetListOperationClaimResponse>>().ReverseMap(); 
        }
    }
}
