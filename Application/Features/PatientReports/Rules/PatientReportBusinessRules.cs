using Application.Features.PatientReports.Constants;
using Application.Repositories;
using Application.Services.AppointmentService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.PatientReports.Rules
{
    public class PatientReportBusinessRules
    {
        private readonly IPatientReportRepository _patientReportRepository;
        private readonly IAppointmentService _appointmentService;

        public PatientReportBusinessRules(IPatientReportRepository patientReportRepository, IAppointmentService appointmentService)
        {
            _patientReportRepository = patientReportRepository;
            _appointmentService = appointmentService;
        }

        public async Task PatientReportShouldBeExist(int id)
        {
            PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == id);
            if (patientReport == null)
            {
                throw new BusinessException(PatientReportsMessages.PatientReportNotExists);
            }
        }

        public async Task PatientReportDeleteControl(int id)
        {
            PatientReport? patientReport = await _patientReportRepository.GetAsync(i => i.Id == id);
            if (patientReport == null || patientReport.IsDeleted == true)
            {
                throw new BusinessException(PatientReportsMessages.PatientReportNotExists);
            }
        }

        public async Task AppointmentShouldBeExist(int id)
        {
            Appointment appointment = await _appointmentService.AppointmentGetById(id);
            if (appointment == null)
            {
                throw new BusinessException(PatientReportsMessages.AppointmentNotExist);
            }
        }
    }
}
