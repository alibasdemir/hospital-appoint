using Application.Features.Doctors.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Queries.GetById
{
    public class GetByIdDoctorQuery : IRequest<GetByIdDoctorResponse>
    {
        public int Id { get; set; }

        public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQuery, GetByIdDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;
            private readonly DoctorBusinessRules _doctorBusinessRules;

            public GetByIdDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules doctorBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _doctorBusinessRules = doctorBusinessRules;
            }

            public async Task<GetByIdDoctorResponse> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                await _doctorBusinessRules.DoctorDeleteControl(request.Id);

                GetByIdDoctorResponse response = _mapper.Map<GetByIdDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
