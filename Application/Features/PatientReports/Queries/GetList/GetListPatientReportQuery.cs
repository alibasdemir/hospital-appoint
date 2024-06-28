using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.PatientReports.Queries.GetList
{
    public class GetListPatientReportQuery : IRequest<GetListResponse<GetListPatientReportResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListatientReportQueryHandler : IRequestHandler<GetListPatientReportQuery, GetListResponse<GetListPatientReportResponse>>
{
            private readonly IPatientReportRepository _patientReportRepository;
            private readonly IMapper _mapper;

            public GetListatientReportQueryHandler(IPatientReportRepository patientReportRepository, IMapper mapper)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListPatientReportResponse>> Handle(GetListPatientReportQuery request, CancellationToken cancellationToken)
            {
                IPaginate<PatientReport> patientReport = await _patientReportRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListPatientReportResponse> response = _mapper.Map<GetListResponse<GetListPatientReportResponse>>(patientReport);
                return response;
            }
        }
    }
}
