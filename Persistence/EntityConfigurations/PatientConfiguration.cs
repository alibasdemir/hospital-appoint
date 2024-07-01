using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            Patient[] patientSeeds =
            {
                new Patient
                {
                    Id = 1,
                    BloodType = BloodType.APositive,
                    InsuranceType = InsuranceType.HealthInsurance,
                    SocialSecurityNumber = "1554447878",
                    HealthHistory = "John Doe, born on January 1, 1980, has a medical history that includes hypertension, Type 2 diabetes, and asthma. He takes 10mg of Lisinopril daily, 500mg of Metformin twice daily, and uses an Albuterol inhaler as needed. In the past, he underwent an appendectomy in 2010 and knee arthroscopy in 2015. He has an allergy to penicillin. His family history shows that his father has hypertension and his mother has Type 2 diabetes. John is a non-smoker and consumes alcohol occasionally.",
                    Allergies = "Penicillin",
                    CurrentMedications = "Lisinopril 10mg daily, Metformin 500mg twice daily",
                    EmergencyContactName = "Lorem Ipsum",
                    EmergencyContactPhoneNumber = "000000",
                    EmergencyContactRelationship = "Father",
                    UserId = 5,
                },
                new Patient
                {
                    Id = 2,
                    BloodType = BloodType.ABNegative,
                    InsuranceType = InsuranceType.PrivateHealthInsurance,
                    SocialSecurityNumber = "9223246896",
                    HealthHistory = "Jane Smith, born on February 15, 1975, has a medical history that includes hypothyroidism, chronic migraines, and osteoarthritis. She takes 50mcg of Levothyroxine daily and Sumatriptan as needed for migraines. In the past, she underwent gallbladder removal surgery in 2012 and a hysterectomy in 2018. She has no known allergies. Her family history includes her father having coronary artery disease and her mother suffering from rheumatoid arthritis. Jane does not smoke and drinks alcohol socially.",
                    Allergies = "None known",
                    CurrentMedications = "Levothyroxine 50mcg daily (for hypothyroidism), Sumatriptan (as needed for migraines)",
                    EmergencyContactName = "Lorem Ipsum",
                    EmergencyContactPhoneNumber = "000000",
                    EmergencyContactRelationship = "Sister",
                    UserId = 6,
                },
            };
            builder.HasData(patientSeeds);
        }
    }
}
