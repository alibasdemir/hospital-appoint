using Application.Features.Patients.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.SoftDelete
{
    public class SoftDeletePatientCommand : IRequest<SoftDeletePatientResponse>
    {
        public int Id { get; set; }


        public class SoftDeletePatientCommandHandler : IRequestHandler<SoftDeletePatientCommand, SoftDeletePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public SoftDeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeletePatientResponse> Handle(SoftDeletePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                if (patient == null)
                {
                    throw new NotFoundException(PatientsMessages.PatientNotExists);
                }
                
                await _patientRepository.SoftDeleteAsync(patient);

                SoftDeletePatientResponse response = _mapper.Map<SoftDeletePatientResponse>(patient);
                return response;
            }
        }
    }
}
