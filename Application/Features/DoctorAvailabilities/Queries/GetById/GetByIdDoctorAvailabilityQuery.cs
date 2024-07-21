using Application.Features.DoctorAvailabilities.Constants;
using Application.Features.DoctorAvailabilities.Rules;
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
            private readonly DoctorAvailabilityBusinessRules _doctorAvailabilityBusinessRules;

            public GetByIdDoctorAvailabilityQueryHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, DoctorAvailabilityBusinessRules doctorAvailabilityBusinessRules)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
                _doctorAvailabilityBusinessRules = doctorAvailabilityBusinessRules;
            }

            public async Task<GetByIdDoctorAvailabilityResponse> Handle(GetByIdDoctorAvailabilityQuery request, CancellationToken cancellationToken)
            {
                DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.Id == request.Id);

                await _doctorAvailabilityBusinessRules.DoctorAvailabilityShouldBeExist(request.Id);

                GetByIdDoctorAvailabilityResponse response = _mapper.Map<GetByIdDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}
