using Application.Features.DoctorAvailabilities.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.DoctorAvailabilities.Constants.DoctorAvailabilityOperationClaims;
using Application.Features.DoctorAvailabilities.Rules;

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
            private readonly DoctorAvailabilityBusinessRules _doctorAvailabilityBusinessRules;

            public UpdateDoctorAvailabilityCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, DoctorAvailabilityBusinessRules doctorAvailabilityBusinessRules)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
                _doctorAvailabilityBusinessRules = doctorAvailabilityBusinessRules;
            }

            public async Task<UpdateDoctorAvailabilityResponse> Handle(UpdateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
            {
                DoctorAvailability? doctorAvailability = _doctorAvailabilityRepository.Get(i => i.Id == request.Id);

                await _doctorAvailabilityBusinessRules.DoctorAvailabilityShouldBeExist(request.Id);
                await _doctorAvailabilityBusinessRules.DoctorShouldBeExist(request.DoctorId);

                _mapper.Map(request, doctorAvailability);

                await _doctorAvailabilityRepository.UpdateAsync(doctorAvailability);

                UpdateDoctorAvailabilityResponse response = _mapper.Map<UpdateDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}
