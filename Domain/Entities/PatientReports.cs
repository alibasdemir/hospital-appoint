using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientReports : Entity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int AppointmentsId { get; set; }
        public Appointments Appointments { get; set; }
        public ReportTitle ReportTitle { get; set; }
        public string ReportDetails { get; set; }
    }

    public enum ReportTitle
    {
        GeneralHealthAssessment,                // Genel Sağlık Durumu Değerlendirmesi
        LaboratoryTestResults,                  // Laboratuvar Test Sonuçları
        DiagnosisAndDiagnosticReport,           // Tanı ve Teşhis Raporu
        TreatmentRecommendations,               // Tedavi Önerileri
        MedicationUsageAndDosageInformation,    // İlaç Kullanımı ve Dozaj Bilgisi
        RadiologyAndImagingReport,              // Radyoloji ve Görüntüleme Raporu
        AllergyAndSensitivityReport,            // Alerji ve Hassasiyet Raporu
        PhysiotherapyAndRehabilitationProgram,  // Fizyoterapi ve Rehabilitasyon Programı
        DiabetesManagementReport,               // Diyabet Yönetimi Raporu
        BloodPressureAndPulseMonitoring         // Kan Basıncı ve Nabız Takibi
    }

}
