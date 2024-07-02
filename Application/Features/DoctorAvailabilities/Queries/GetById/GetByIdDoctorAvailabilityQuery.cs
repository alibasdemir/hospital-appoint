using Application.Features.DoctorAvailabilities.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.DoctorAvailabilities.Queries.GetById
{
    public class GetByIdDoctorAvailabilityQuery : IRequest<GetByIdDoctorAvailabilityResponse>
    {
        public int Id { get; set; }

        public class GetByIdDoctorAvailabilityQueryHandler : IRequestHandler<GetByIdDoctorAvailabilityQuery, GetByIdDoctorAvailabilityResponse>
        {
            private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
            private readonly IMapper _mapper;

            public GetByIdDoctorAvailabilityQueryHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdDoctorAvailabilityResponse> Handle(GetByIdDoctorAvailabilityQuery request, CancellationToken cancellationToken)
            {
                DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.Id == request.Id);

                if (doctorAvailability == null || doctorAvailability.IsDeleted == true)
                {
                    throw new NotFoundException(DoctorAvailabilityMessages.DoctorAvailabilityNotExists);
                }

                GetByIdDoctorAvailabilityResponse response = _mapper.Map<GetByIdDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}
