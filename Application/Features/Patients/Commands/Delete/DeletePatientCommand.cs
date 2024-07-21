using Application.Features.PatientReports.Constants;
using Application.Features.Patients.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.Delete
{
    public class DeletePatientCommand : IRequest<DeletePatientResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Delete };
        public int Id { get; set; }

        public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, DeletePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;
            private readonly PatientBusinessRules _patientBusinessRules;
            public DeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, PatientBusinessRules patientBusinessRules)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
                _patientBusinessRules = patientBusinessRules;
            }

            public async Task<DeletePatientResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                await _patientBusinessRules.PatientShouldBeExist(request.Id);

                await _patientRepository.DeleteAsync(patient);
                DeletePatientResponse response = _mapper.Map<DeletePatientResponse>(patient);
                return response;
            }
        }
    }
}
