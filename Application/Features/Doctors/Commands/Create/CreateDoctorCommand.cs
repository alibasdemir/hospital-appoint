using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;

namespace Application.Features.Doctors.Commands.Create
{
    public class CreateDoctorCommand : IRequest<CreateDoctorResponse>, ISecuredRequest, ILoggableRequest
    {
        public string SpecialistLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }

        public string[] RequiredRoles => new[] { Admin, Write, Add };

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
