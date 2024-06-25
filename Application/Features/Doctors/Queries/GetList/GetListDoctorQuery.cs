using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Queries.GetList
{
    public class GetListDoctorQuery : IRequest<GetListResponse<GetListDoctorResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListDoctorQueryHandler : IRequestHandler<GetListDoctorQuery, GetListResponse<GetListDoctorResponse>>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetListDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListDoctorResponse>> Handle(GetListDoctorQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Doctor> doctors = await _doctorRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetListDoctorResponse>>(doctors);
                return response;
            }
        }
    }
}
