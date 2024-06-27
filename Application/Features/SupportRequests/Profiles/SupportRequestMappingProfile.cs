using Application.Features.SupportRequests.Commands.Create;
using Application.Features.SupportRequests.Commands.Delete;
using Application.Features.SupportRequests.Commands.SoftDelete;
using Application.Features.SupportRequests.Commands.Update;
using AutoMapper;
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
        }
    }
}
