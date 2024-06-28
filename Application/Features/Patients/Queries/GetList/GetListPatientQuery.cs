using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Patients.Queries.GetList
{
    public class GetListPatientQuery : IRequest<GetListResponse<GetListPatientResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, GetListResponse<GetListPatientResponse>>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public GetListPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListPatientResponse>> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Patient> patient = await _patientRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListPatientResponse> response = _mapper.Map<GetListResponse<GetListPatientResponse>>(patient);
                return response;
            }
        }
    }
}
