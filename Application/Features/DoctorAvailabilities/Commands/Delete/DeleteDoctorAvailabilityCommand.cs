using Application.Features.DoctorAvailabilities.Constants;
using Application.Features.DoctorAvailabilities.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.DoctorAvailabilities.Constants.DoctorAvailabilityOperationClaims;

namespace Application.Features.DoctorAvailabilities.Commands.Delete
{
    public class DeleteDoctorAvailabilityCommand : IRequest<DeleteDoctorAvailabilityResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, DoctorAvailabilityOperationClaims.Delete];
        public int Id { get; set; }

        public class DeleteDoctorAvailabilityCommandHandler : IRequestHandler<DeleteDoctorAvailabilityCommand, DeleteDoctorAvailabilityResponse>
        {
            private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
            private readonly IMapper _mapper;
            private readonly DoctorAvailabilityBusinessRules _doctorAvailabilityBusinessRules;

            public DeleteDoctorAvailabilityCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, DoctorAvailabilityBusinessRules doctorAvailabilityBusinessRules)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
                _doctorAvailabilityBusinessRules = doctorAvailabilityBusinessRules;
            }

            public async Task<DeleteDoctorAvailabilityResponse> Handle(DeleteDoctorAvailabilityCommand request, CancellationToken cancellationToken)
            {
                DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.Id == request.Id);

                await _doctorAvailabilityBusinessRules.DoctorAvailabilityShouldBeExist(request.Id);

                await _doctorAvailabilityRepository.DeleteAsync(doctorAvailability);
                DeleteDoctorAvailabilityResponse response = _mapper.Map<DeleteDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}
