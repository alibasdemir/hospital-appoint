using Application.Features.SupportRequests.Commands.Create;
using Application.Features.SupportRequests.Commands.Delete;
using Application.Features.SupportRequests.Commands.SoftDelete;
using Application.Features.SupportRequests.Commands.Update;
using Application.Features.SupportRequests.Queries.GetById;
using Application.Features.SupportRequests.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;

namespace Application.Features.SupportRequests.Profiles
{
    public class SupportRequestMappingProfile : Profile
    {
        public SupportRequestMappingProfile()
        {
            CreateMap<SupportRequest, CreateSupportRequestCommand>().ReverseMap();
            CreateMap<SupportRequest, CreateSupportRequestResponse>().ReverseMap();
            CreateMap<SupportRequest, DeleteSupportRequestCommand>().ReverseMap();
            CreateMap<SupportRequest, DeleteSupportRequestResponse>().ReverseMap();
            CreateMap<SupportRequest, SoftDeleteSupportRequestCommand>().ReverseMap();
            CreateMap<SupportRequest, SoftDeleteSupportRequestResponse>().ReverseMap();
            CreateMap<SupportRequest, UpdateSupportRequestCommand>().ReverseMap();
            CreateMap<SupportRequest, UpdateSupportRequestResponse>().ReverseMap();
            CreateMap<SupportRequest, GetByIdSupportRequestQuery>().ReverseMap();
            CreateMap<SupportRequest, GetByIdSupportRequestResponse>().ReverseMap();
            CreateMap<SupportRequest, GetListSupportRequestQuery>().ReverseMap();
            CreateMap<SupportRequest, GetListSupportRequestResponse>().ReverseMap();
            CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListSupportRequestResponse>>().ReverseMap();
        }
    }
}
