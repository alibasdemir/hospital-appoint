using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.Create
{
    public class CreateDoctorCommand : IRequest<CreateDoctorResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string SpecialistLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public string Qualifications { get; set; }
        public int DepartmentId { get; set; }
        //public Department DepartmentName { get; set; }
        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;

            public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
            {
                _doctorRepository = doctorRepository;
            }

            public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor doctor = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    Email = request.Email,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    PhotoUrl = request.PhotoUrl,
                    SpecialistLevel = request.SpecialistLevel,
                    YearsOfExperience = request.YearsOfExperience,
                    Biography = request.Biography,
                    Qualifications = request.Qualifications,
                    DepartmentId = request.DepartmentId,
                };
                await _doctorRepository.AddAsync(doctor);
                return new CreateDoctorResponse()
                {
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Gender = doctor.Gender,
                    Email = doctor.Email,
                    Password = doctor.Password,
                    PhoneNumber = doctor.PhoneNumber,
                    Address = doctor.Address,
                    PhotoUrl = doctor.PhotoUrl,
                    SpecialistLevel = doctor.SpecialistLevel,
                    YearsOfExperience = doctor.YearsOfExperience,
                    Biography = doctor.Biography,
                    Qualifications = doctor.Qualifications,
                    DepartmentId = doctor.DepartmentId,
                    //Department = doctor.Department
                };
            }
        }
    }
}
