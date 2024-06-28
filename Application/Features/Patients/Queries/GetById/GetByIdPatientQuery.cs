using Application.Features.Patients.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

            public GetByIdPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdPatientResponse> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                if (patient == null || patient.IsDeleted == true)
                {
                    throw new NotFoundException(PatientsMessages.PatientNotExists);
                }

                GetByIdPatientResponse response = _mapper.Map<GetByIdPatientResponse>(patient);
                return response;
            }
        }
    }
}
