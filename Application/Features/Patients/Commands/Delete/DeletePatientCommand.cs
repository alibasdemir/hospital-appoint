using Application.Features.Patients.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.Delete
{
    public class DeletePatientCommand : IRequest<DeletePatientResponse>
    {
        public int Id { get; set; }

        public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, DeletePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;
            public DeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<DeletePatientResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                if (patient == null)
                {
                    throw new NotFoundException(PatientsMessages.PatientNotExists);
                }

                await _patientRepository.DeleteAsync(patient);
                DeletePatientResponse response = _mapper.Map<DeletePatientResponse>(patient);
                return response;
            }
        }
    }
}
