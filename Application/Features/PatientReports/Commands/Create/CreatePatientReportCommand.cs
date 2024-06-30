using Application.Features.Appointments.Constants;
using Application.Repositories;
using Application.Services.AppointmentService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
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
			private readonly IAppointmentService _appointmentService;

			public CreatePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper, IAppointmentService appointmentService)
			{
				_patientReportRepository = patientReportRepository;
				_mapper = mapper;
				_appointmentService = appointmentService;
			}

			public async Task<CreatePatientReportResponse> Handle(CreatePatientReportCommand request, CancellationToken cancellationToken)
			{
				bool isAppointmentExist = await _appointmentService.AppointmentValidationById(request.AppointmentId);

				if (isAppointmentExist)
				{
					PatientReport patientReport = _mapper.Map<PatientReport>(request);
					await _patientReportRepository.AddAsync(patientReport);

					CreatePatientReportResponse response = _mapper.Map<CreatePatientReportResponse>(patientReport);
					return response;
				}
				throw new NotFoundException(AppointmentsMessages.AppointmentNotExists);
			}
		}
	}
}
