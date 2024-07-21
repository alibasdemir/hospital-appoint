using Application.Features.PatientReports.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PatientReports.Queries.GetById
{
    public class GetByIdPatientReportQuery : IRequest<GetByIdPatientReportResponse>
    {
        public int Id { get; set; }

        public class GetByIdPatientReportQueryHandler : IRequestHandler<GetByIdPatientReportQuery, GetByIdPatientReportResponse>
        {
            private readonly IPatientReportRepository _patientReportRepository;
            private readonly IMapper _mapper;
            private readonly PatientReportBusinessRules _patientReportBusinessRules;

            public GetByIdPatientReportQueryHandler(IPatientReportRepository patientReportRepository, IMapper mapper, PatientReportBusinessRules patientReportBusinessRules)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
                _patientReportBusinessRules = patientReportBusinessRules;
            }

            public async Task<GetByIdPatientReportResponse> Handle(GetByIdPatientReportQuery request, CancellationToken cancellationToken)
            {
                PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id  == request.Id);

                await _patientReportBusinessRules.PatientReportDeleteControl(request.Id);

                GetByIdPatientReportResponse response = _mapper.Map<GetByIdPatientReportResponse>(patientReport);
                return response;
            }
        }
    }
}
