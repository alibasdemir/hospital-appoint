using Application.Features.PatientReports.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.PatientReports.Constants.PatientReportsOperationClaims;

namespace Application.Features.PatientReports.Commands.SoftDelete
{
    public class SoftDeletePatientReportCommand : IRequest<SoftDeletePatientReportResponse>
    {
        public int Id { get; set; }


        public class SoftDeletePatientReportCommandHandler : IRequestHandler<SoftDeletePatientReportCommand, SoftDeletePatientReportResponse>
        {
            private readonly IPatientReportRepository _patientReportRepository;
            private readonly IMapper _mapper;

            public SoftDeletePatientReportCommandHandler(IPatientReportRepository patientReportRepository, IMapper mapper)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeletePatientReportResponse> Handle(SoftDeletePatientReportCommand request, CancellationToken cancellationToken)
            {
                PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == request.Id);

                if (patientReport == null)
                {
                    throw new NotFoundException(PatientReportsMessages.PatientReportNotExists);
                }
                
                await _patientReportRepository.SoftDeleteAsync(patientReport);

                SoftDeletePatientReportResponse response = _mapper.Map<SoftDeletePatientReportResponse>(patientReport);
                return response;
            }
        }
    }
}
