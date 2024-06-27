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
using Application.Features.Doctors.Constants;
using Application.Features.DoctorAvailabilities.Commands.Create;

namespace Application.Features.DoctorAvailabilities.Commands.Update
{
	public class UpdateDoctorAvailabilityCommand : IRequest<UpdateDoctorAvailabilityResponse>
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }


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
				DoctorAvailability? doctorAvailability = _doctorAvailabilityRepository.Get(i => i.Id == request.Id);

				if (!isDoctorExist)
				{
					throw new NotFoundException(DoctorsMessages.DoctorNotExists);
				}

				if (doctorAvailability is null)
				{
					doctorAvailability = _mapper.Map<DoctorAvailability>(request);
					await _doctorAvailabilityRepository.UpdateAsync(doctorAvailability);
				}
				UpdateDoctorAvailabilityResponse response = _mapper.Map<UpdateDoctorAvailabilityResponse>(doctorAvailability);
				return response;
			}
		}
	}
}
