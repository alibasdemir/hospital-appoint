using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Create
{
    public class CreatePatientCommand : IRequest<CreatePatientResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string BloodType { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string HealthHistory { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public bool HasInsurance { get; set; }
        public string InsuranceType { get; set; }

        public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;

            public CreatePatientCommandHandler(IPatientRepository patientRepository)
            {
                _patientRepository = patientRepository;
            }

            public async Task<CreatePatientResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
            {
                Patient patient = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    Email = request.Email,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    PhotoUrl = request.PhotoUrl,
                    BirthDate = request.BirthDate,
                    BloodType = request.BloodType,
                    SocialSecurityNumber = request.SocialSecurityNumber,
                    HealthHistory = request.HealthHistory,
                    Allergies = request.Allergies,
                    CurrentMedications = request.CurrentMedications,
                    EmergencyContactName = request.EmergencyContactName,
                    EmergencyContactPhoneNumber = request.EmergencyContactPhoneNumber,
                    EmergencyContactRelationship = request.EmergencyContactRelationship,
                    HasInsurance = request.HasInsurance,
                    InsuranceType = request.InsuranceType
                };
                await _patientRepository.AddAsync(patient);
                return new CreatePatientResponse()
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Gender = patient.Gender,
                    Email = patient.Email,
                    Password = patient.Password,
                    PhoneNumber = patient.PhoneNumber,
                    Address = patient.Address,
                    PhotoUrl= patient.PhotoUrl,
                    BirthDate = patient.BirthDate,
                    BloodType = patient.BloodType,
                    SocialSecurityNumber= patient.SocialSecurityNumber,
                    HealthHistory = patient.HealthHistory,
                    Allergies = patient.Allergies,
                    CurrentMedications = patient.CurrentMedications,
                    EmergencyContactName= patient.EmergencyContactName,
                    EmergencyContactPhoneNumber= patient.EmergencyContactPhoneNumber,
                    EmergencyContactRelationship= patient.EmergencyContactRelationship,
                    HasInsurance= patient.HasInsurance,
                    InsuranceType= patient.InsuranceType
                };
            }
        }
    }
}
