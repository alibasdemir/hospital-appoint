using Application.Features.PatientReports.Constants;
using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;


namespace Application.Features.Patients.Commands.Create
{
    public class CreatePatientCommand : IRequest<CreatePatientResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, Write, Add };
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

		public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientResponse>
		{
			private readonly IPatientRepository _patientRepository;
			private readonly IMapper _mapper;
			private readonly IUserService _userService;

			public CreatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, IUserService userService)
			{
				_patientRepository = patientRepository;
				_mapper = mapper;
				_userService = userService;
			}

			public async Task<CreatePatientResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
			{
				User user = await _userService.GetUserByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new NotFoundException("User not found.");
                }

				user.UserType = "patient";
				await _userService.UpdateUserAsync(user);

				Patient patient = _mapper.Map<Patient>(request);
				patient.UserId = user.Id;
				await _patientRepository.AddAsync(patient);

				CreatePatientResponse response = _mapper.Map<CreatePatientResponse>(patient);
				return response;
			}
		}
	}
}
