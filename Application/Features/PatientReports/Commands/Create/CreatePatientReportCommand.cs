using Application.Features.PatientReports.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.PatientReports.Constants.PatientReportsOperationClaims;

namespace Application.Features.PatientReports.Commands.Create
{
	public class CreatePatientReportCommand : IRequest<CreatePatientReportResponse>, ISecuredRequest, ILoggableRequest
    {
		public string[] RequiredRoles => new[] { Admin, Write, Add };

        public int AppointmentId { get; set; }
		public string Title { get; set; }
		public string Details { get; set; }

		public class CreatePatientReportCommandHandler : IRequestHandler<CreatePatientReportCommand, CreatePatientReportResponse>
		{
			private readonly IPatientReportRepository _patientReportRepository;
			private readonly IMapper _mapper;
			private readonly PatientReportBusinessRules _patientReportBusinessRules;

            public CreatePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper, PatientReportBusinessRules patientReportBusinessRules)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
                _patientReportBusinessRules = patientReportBusinessRules;
            }

            public async Task<CreatePatientReportResponse> Handle(CreatePatientReportCommand request, CancellationToken cancellationToken)
			{
				await _patientReportBusinessRules.AppointmentShouldBeExist(request.AppointmentId);
				
				PatientReport patientReport = _mapper.Map<PatientReport>(request);
				await _patientReportRepository.AddAsync(patientReport);
				
				CreatePatientReportResponse response = _mapper.Map<CreatePatientReportResponse>(patientReport);
				return response;
			}
		}
	}
}
