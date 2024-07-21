using Application.Features.PatientReports.Constants;
using Application.Features.PatientReports.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.PatientReports.Constants.PatientReportsOperationClaims;

namespace Application.Features.PatientReports.Commands.SoftDelete
{
    public class SoftDeletePatientReportCommand : IRequest<SoftDeletePatientReportResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeletePatientReportCommandHandler : IRequestHandler<SoftDeletePatientReportCommand, SoftDeletePatientReportResponse>
        {
            private readonly IPatientReportRepository _patientReportRepository;
            private readonly IMapper _mapper;
            private readonly PatientReportBusinessRules _patientReportBusinessRules;

            public SoftDeletePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper, PatientReportBusinessRules patientReportBusinessRules)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
                _patientReportBusinessRules = patientReportBusinessRules;
            }

            public async Task<SoftDeletePatientReportResponse> Handle(SoftDeletePatientReportCommand request, CancellationToken cancellationToken)
            {
                PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == request.Id);

                await _patientReportBusinessRules.PatientReportDeleteControl(request.Id);
                
                await _patientReportRepository.SoftDeleteAsync(patientReport);

                SoftDeletePatientReportResponse response = _mapper.Map<SoftDeletePatientReportResponse>(patientReport);
                return response;
            }
        }
    }
}
