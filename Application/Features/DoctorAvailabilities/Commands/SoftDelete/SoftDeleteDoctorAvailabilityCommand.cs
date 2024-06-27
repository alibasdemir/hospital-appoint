using Application.Features.DoctorAvailabilities.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.DoctorAvailabilities.Constants.DoctorAvailabilityOperationClaims;

namespace Application.Features.DoctorAvailabilities.Commands.SoftDelete
{
    public class SoftDeleteDoctorAvailabilityCommand : IRequest<SoftDeleteDoctorAvailabilityResponse>
    {
        public int Id { get; set; }

        public class SoftDeleteDoctorAvailabilityCommandHandler : IRequestHandler<SoftDeleteDoctorAvailabilityCommand, SoftDeleteDoctorAvailabilityResponse>
        {
            private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
            private readonly IMapper _mapper;

            public SoftDeleteDoctorAvailabilityCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteDoctorAvailabilityResponse> Handle(SoftDeleteDoctorAvailabilityCommand request, CancellationToken cancellationToken)
            {
                DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.Id == request.Id);

                if (doctorAvailability == null)
                {
                    throw new NotFoundException(DoctorAvailabilityMessages.DoctorAvailabilityNotExists);
                }

                await _doctorAvailabilityRepository.SoftDeleteAsync(doctorAvailability);

                SoftDeleteDoctorAvailabilityResponse response = _mapper.Map<SoftDeleteDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}
