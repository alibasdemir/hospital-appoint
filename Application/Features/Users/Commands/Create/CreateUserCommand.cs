using Application.Features.Users.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using Application.Services.PatientService;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Hashing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>, ILoggableRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IPatientService _patientService;
            private readonly IDoctorService _doctorService;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPatientService patientService, IDoctorService doctorService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _patientService = patientService;
                _doctorService = doctorService;
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                if (request.UserType == "doctor")
                {
                    await _userRepository.AddAsync(user);
                    Doctor doctor = _mapper.Map<Doctor>(request);
                    doctor.UserId = user.Id;
                    await _doctorService.AddDoctorAsync(doctor);
                }
                else if (request.UserType == "patient")
                {
                    await _userRepository.AddAsync(user);
                    Patient patient = _mapper.Map<Patient>(request);
                    patient.UserId = user.Id;
                    await _patientService.AddPatientAsync(patient);
                }
                else
                {
                    throw new BusinessException(UsersMessages.ValidUserType);
                }

                CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
                return response;
            }
        }
    }
}

