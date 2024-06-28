using Application.Features.PatientReports.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.PatientReports.Queries.GetById
{
    public class GetByIdPatientReportQuery : IRequest<GetByIdPatientReportResponse>
    {
        public int Id { get; set; }

        public class GetByIdPatientReportQueryHandler : IRequestHandler<GetByIdPatientReportQuery, GetByIdPatientReportResponse>
        {
            private readonly IPatientReportRepository _patientReportRepository;
            private readonly IMapper _mapper;

            public GetByIdPatientReportQueryHandler(IPatientReportRepository patientReportRepository, IMapper mapper)
            {
                _patientReportRepository = patientReportRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdPatientReportResponse> Handle(GetByIdPatientReportQuery request, CancellationToken cancellationToken)
            {
                PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id  == request.Id);

                if (patientReport == null || patientReport.IsDeleted == true) 
                {
                    throw new NotFoundException(PatientReportsMessages.PatientReportNotExists);
                }

                GetByIdPatientReportResponse response = _mapper.Map<GetByIdPatientReportResponse>(patientReport);
                return response;
            }
        }
    }
}
