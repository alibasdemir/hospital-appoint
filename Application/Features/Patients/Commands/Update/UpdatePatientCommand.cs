using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Patients.Commands.Update
{
	public class UpdatePatientCommand : IRequest<UpdatePatientResponse>
	{
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
			private readonly IUserService _userService;

			public UpdatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, IUserService userService)
			{
				_patientRepository = patientRepository;
				_mapper = mapper;
				_userService = userService;
			}

			public async Task<UpdatePatientResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
			{
				bool isUserExist = await _userService.UserValidationById(request.UserId);

				if (!isUserExist)
				{
					throw new NotFoundException(UsersMessages.UserNotExists);
				}

				Patient patient = _mapper.Map<Patient>(request);
				await _patientRepository.AddAsync(patient);

				UpdatePatientResponse response = _mapper.Map<UpdatePatientResponse>(patient);
				return response;
			}
		}
	}
}
