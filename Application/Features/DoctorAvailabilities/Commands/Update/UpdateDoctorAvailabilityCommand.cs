using Application.Features.DoctorAvailabilities.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.DoctorAvailabilities.Constants.DoctorAvailabilityOperationClaims;

namespace Application.Features.DoctorAvailabilities.Commands.Update
{
	public class UpdateDoctorAvailabilityCommand : IRequest<UpdateDoctorAvailabilityResponse>, ILoggableRequest, ISecuredRequest
    {
		public DateTime AvailableDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }

		public string[] RequiredRoles => new[] { Admin, Write, DoctorAvailabilityOperationClaims.Update };

        public class UpdateDoctorAvailabilityCommandHandler : IRequestHandler<UpdateDoctorAvailabilityCommand, UpdateDoctorAvailabilityResponse>
		{
			private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
			private readonly IMapper _mapper;
			private readonly IDoctorService _doctorService;

			public UpdateDoctorAvailabilityCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, IDoctorService doctorService)
			{
				_doctorAvailabilityRepository = doctorAvailabilityRepository;
				_mapper = mapper;
				_doctorService = doctorService;
			}

			public async Task<UpdateDoctorAvailabilityResponse> Handle(UpdateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
			{
				bool isDoctorExist = await _doctorService.DoctorValidationById(request.DoctorId);

				if (!isDoctorExist)
				{
                    throw new NotFoundException("Böyle bir doktor yok");
                }
				

                DoctorAvailability doctorAvailability = _mapper.Map<DoctorAvailability>(request);
                await _doctorAvailabilityRepository.UpdateAsync(doctorAvailability);

                UpdateDoctorAvailabilityResponse response = _mapper.Map<UpdateDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
		}
	}
}
