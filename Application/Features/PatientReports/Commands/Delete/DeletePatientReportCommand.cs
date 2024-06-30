using Application.Features.PatientReports.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
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
            public DeletePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
            }

            public async Task<DeletePatientReportResponse> Handle(DeletePatientReportCommand request, CancellationToken cancellationToken)
            {
                PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == request.Id);

                if (patientReport == null)
                {
                    throw new NotFoundException(PatientReportsMessages.PatientReportNotExists);
                }

                await _patientReportRepository.DeleteAsync(patientReport);
                DeletePatientReportResponse response = _mapper.Map<DeletePatientReportResponse>(patientReport);
                return response;
            }
        }
    }
}
