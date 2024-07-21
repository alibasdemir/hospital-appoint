using Application.Features.PatientReports.Constants;
using Application.Features.PatientReports.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.PatientReports.Constants.PatientReportsOperationClaims;

namespace Application.Features.PatientReports.Commands.Delete
{
    public class DeletePatientReportCommand : IRequest<DeletePatientReportResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Delete };
        public int Id { get; set; }

        public class DeletePatientReportCommandHandler : IRequestHandler<DeletePatientReportCommand, DeletePatientReportResponse>
        {
            private readonly IPatientReportRepository _patientReportRepository;
            private readonly IMapper _mapper;
            private readonly PatientReportBusinessRules _patientReportBusinessRules;
            public DeletePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper, PatientReportBusinessRules patientReportBusinessRules)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
                _patientReportBusinessRules = patientReportBusinessRules;
            }

            public async Task<DeletePatientReportResponse> Handle(DeletePatientReportCommand request, CancellationToken cancellationToken)
            {
                PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == request.Id);

                await _patientReportBusinessRules.PatientReportShouldBeExist(request.Id);

                await _patientReportRepository.DeleteAsync(patientReport);
                DeletePatientReportResponse response = _mapper.Map<DeletePatientReportResponse>(patientReport);
                return response;
            }
        }
    }
}
