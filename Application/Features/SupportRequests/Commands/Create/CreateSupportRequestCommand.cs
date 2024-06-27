using Application.Repositories;
using Application.Services.DoctorAvailabilityService;
using Application.Services.PatientService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;

using Application.Features.Patients.Constants;
using Application.Features.DoctorAvailabilities.Constants;

namespace Application.Features.SupportRequests.Commands.Create
{
	public class CreateSupportRequestCommand : IRequest<CreateSupportRequestResponse>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public class CreateSupportRequestCommandHandler : IRequestHandler<CreateSupportRequestCommand, CreateSupportRequestResponse>
		{
			private readonly ISupportRequestRepository _supportRequestRepository;
			private readonly IMapper _mapper;

			public CreateSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper, IPatientService patientService)
			{
				_supportRequestRepository = supportRequestRepository;
				_mapper = mapper;
			}

			public async Task<CreateSupportRequestResponse> Handle(CreateSupportRequestCommand request, CancellationToken cancellationToken)
			{
				SupportRequest supportRequest = _mapper.Map<SupportRequest>(request);
				await _supportRequestRepository.AddAsync(supportRequest);
				CreateSupportRequestResponse response = _mapper.Map<CreateSupportRequestResponse>(supportRequest);
				return response;

			}
		}
	}
}
