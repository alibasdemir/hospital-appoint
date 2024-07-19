using Application.Features.Doctors.Rules;
using Application.Features.PatientReports.Constants;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;

namespace Application.Features.Doctors.Commands.Create
{
    public class CreateDoctorCommand : IRequest<CreateDoctorResponse>, ILoggableRequest, ISecuredRequest
    {
        public string[] RequiredRoles => new[] { Admin, Write, Add };
        public string SpecialistLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }

        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;
            private readonly DoctorBusinessRules _doctorBusinessRules;

            public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, IUserService userService, DoctorBusinessRules doctorBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _userService = userService;
                _doctorBusinessRules = doctorBusinessRules;
            }

            public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetUserByIdAsync(request.UserId);

                await _doctorBusinessRules.UserShouldBeExist(request.UserId);

                user.UserType = "doctor";
                await _userService.UpdateUserAsync(user);

                Doctor doctor = _mapper.Map<Doctor>(request);
                doctor.UserId = user.Id;
                await _doctorRepository.AddAsync(doctor);

                CreateDoctorResponse response = _mapper.Map<CreateDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
