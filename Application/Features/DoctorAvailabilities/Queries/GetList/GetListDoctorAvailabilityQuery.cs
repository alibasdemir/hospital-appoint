using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.DoctorAvailabilities.Queries.GetList
{
    public class GetListDoctorAvailabilityQuery : IRequest<GetListResponse<GetListDoctorAvailabilityResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListDoctorAvailabilityQueryHandler : IRequestHandler<GetListDoctorAvailabilityQuery, GetListResponse<GetListDoctorAvailabilityResponse>>
        {
            private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
            private readonly IMapper _mapper;

            public GetListDoctorAvailabilityQueryHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListDoctorAvailabilityResponse>> Handle(GetListDoctorAvailabilityQuery request, CancellationToken cancellationToken)
            {
                IPaginate<DoctorAvailability> doctorAvailability = await _doctorAvailabilityRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListDoctorAvailabilityResponse> response = _mapper.Map<GetListResponse<GetListDoctorAvailabilityResponse>>(doctorAvailability);

                return response;
            }
        }
    }
}
