using Application.Features.Appointments.Constants;
using Application.Features.PatientReports.Commands.Update;
using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.PatientReports.Commands.Update
{
	public class UpdatePatientReportCommand : IRequest<UpdatePatientReportResponse>
	{
		public DateTime AvailableDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }

		public class UpdatePatientReportCommandHandler : IRequestHandler<UpdatePatientReportCommand, UpdatePatientReportResponse>
		{
			private readonly IPatientReportRepository _patientReportRepository;
			private readonly IMapper _mapper;
			private readonly IDoctorService _doctorService;

			public UpdatePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper, IDoctorService doctorService)
			{
				_patientReportRepository = patientReportRepository;
				_mapper = mapper;
				_doctorService = doctorService;
			}

			public async Task<UpdatePatientReportResponse> Handle(UpdatePatientReportCommand request, CancellationToken cancellationToken)
			{
				bool isDoctorExist = await _doctorService.DoctorValidationById(request.DoctorId);

				if (isDoctorExist)
				{
					PatientReport patientReport = _mapper.Map<PatientReport>(request);
					await _patientReportRepository.UpdateAsync(patientReport);

					UpdatePatientReportResponse response = _mapper.Map<UpdatePatientReportResponse>(patientReport);
					return response;
				}
				throw new NotFoundException(AppointmentsMessages.AppointmentNotExists);
			}
		}
	}
}
