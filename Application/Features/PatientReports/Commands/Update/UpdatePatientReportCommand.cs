using Application.Features.Appointments.Constants;
using Application.Features.PatientReports.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.PatientReports.Constants.PatientReportsOperationClaims;

namespace Application.Features.PatientReports.Commands.Update
{
	public class UpdatePatientReportCommand : IRequest<UpdatePatientReportResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Update };
		public int Id { get; set; }
		public int AppointmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

		public class UpdatePatientReportCommandHandler : IRequestHandler<UpdatePatientReportCommand, UpdatePatientReportResponse>
		{
			private readonly IPatientReportRepository _patientReportRepository;
			private readonly IMapper _mapper;

			public UpdatePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper)
			{
				_patientReportRepository = patientReportRepository;
				_mapper = mapper;
			}

			public async Task<UpdatePatientReportResponse> Handle(UpdatePatientReportCommand request, CancellationToken cancellationToken)
			{
				PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == request.Id);

				if (patientReport == null|| patientReport.IsDeleted == true)
				{
					throw new NotFoundException(PatientReportsMessages.PatientReportNotExists);
				}

				_mapper.Map(request, patientReport);

				await _patientReportRepository.UpdateAsync(patientReport);

				UpdatePatientReportResponse response = _mapper.Map<UpdatePatientReportResponse>(patientReport);
				return response;
			}
		}
	}
}
