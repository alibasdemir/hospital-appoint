using Application.Features.Patients.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Patients.Queries.GetById
{
    public class GetByIdPatientQuery : IRequest<GetByIdPatientResponse>
    {
        public int Id { get; set; }

        public class GetByIdPatientQueryHandler : IRequestHandler<GetByIdPatientQuery, GetByIdPatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;
            private readonly PatientBusinessRules _patientBusinessRules;

            public GetByIdPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper, PatientBusinessRules patientBusinessRules)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
                _patientBusinessRules = patientBusinessRules;
            }

            public async Task<GetByIdPatientResponse> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                await _patientBusinessRules.PatientDeleteControl(request.Id);

                GetByIdPatientResponse response = _mapper.Map<GetByIdPatientResponse>(patient);
                return response;
            }
        }
    }
}
