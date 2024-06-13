using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string SpecialistLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public int DepartmentId { get; set; }
        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor doctor = _mapper.Map<Doctor>(request);
                await _doctorRepository.AddAsync(doctor);
                CreateDoctorResponse response = _mapper.Map<CreateDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
