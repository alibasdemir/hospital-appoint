using Application.Features.PatientReports.Constants;
using Application.Features.Patients.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.Update
{
	public class UpdatePatientCommand : IRequest<UpdatePatientResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Update };
		public int Id { get; set; }
        public int UserId { get; set; }
		public BloodType BloodType { get; set; }
		public InsuranceType InsuranceType { get; set; }
		public string SocialSecurityNumber { get; set; }
		public string HealthHistory { get; set; }
		public string Allergies { get; set; }
		public string CurrentMedications { get; set; }
		public string EmergencyContactName { get; set; }
		public string EmergencyContactPhoneNumber { get; set; }
		public string EmergencyContactRelationship { get; set; }

		public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientResponse>
		{
			private readonly IPatientRepository _patientRepository;
			private readonly IMapper _mapper;
			private readonly PatientBusinessRules _patientBusinessRules;

            public UpdatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, PatientBusinessRules patientBusinessRules)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
                _patientBusinessRules = patientBusinessRules;
            }

            public async Task<UpdatePatientResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
			{
				Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

				await _patientBusinessRules.PatientDeleteControl(request.Id);

				_mapper.Map(request, patient);

				await _patientRepository.UpdateAsync(patient);

				UpdatePatientResponse response = _mapper.Map<UpdatePatientResponse>(patient);
				return response;
			}
		}
	}
}
