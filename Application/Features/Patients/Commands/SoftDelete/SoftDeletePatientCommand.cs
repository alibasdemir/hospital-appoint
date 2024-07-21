using Application.Features.PatientReports.Constants;
using Application.Features.Patients.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.SoftDelete
{
    public class SoftDeletePatientCommand : IRequest<SoftDeletePatientResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeletePatientCommandHandler : IRequestHandler<SoftDeletePatientCommand, SoftDeletePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;
            private readonly PatientBusinessRules _patientBusinessRules;

            public SoftDeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, PatientBusinessRules patientBusinessRules)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
                _patientBusinessRules = patientBusinessRules;
            }

            public async Task<SoftDeletePatientResponse> Handle(SoftDeletePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                await _patientBusinessRules.PatientDeleteControl(request.Id);

                await _patientRepository.SoftDeleteAsync(patient);

                await _patientBusinessRules.PatientDeleteWithUser(request.Id);

                await _patientBusinessRules.PatientDeleteWithUser(request.Id);

                SoftDeletePatientResponse response = _mapper.Map<SoftDeletePatientResponse>(patient);
                return response;
            }
        }
    }
}
