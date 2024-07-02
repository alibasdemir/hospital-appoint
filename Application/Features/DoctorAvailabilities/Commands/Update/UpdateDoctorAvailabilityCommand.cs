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

namespace Application.Features.DoctorAvailabilities.Commands.Update
{
    public class UpdateDoctorAvailabilityCommand : IRequest<UpdateDoctorAvailabilityResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, DoctorAvailabilityOperationClaims.Update];
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

                if (doctorAvailability == null || doctorAvailability.IsDeleted == true)
                {
                    throw new NotFoundException(DoctorAvailabilityMessages.DoctorAvailabilityNotExists);
                }
                if (!isDoctorExist)
                {
                    throw new NotFoundException(DoctorsMessages.DoctorNotExists);
                }

                _mapper.Map(request, doctorAvailability);

                await _doctorAvailabilityRepository.UpdateAsync(doctorAvailability);

                UpdateDoctorAvailabilityResponse response = _mapper.Map<UpdateDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}
