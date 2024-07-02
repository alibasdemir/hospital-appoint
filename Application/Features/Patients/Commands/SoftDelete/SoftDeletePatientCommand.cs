using Application.Features.PatientReports.Constants;
using Application.Features.Patients.Constants;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.SoftDelete
{
    public class SoftDeletePatientCommand : IRequest<SoftDeletePatientResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, PatientReportsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeletePatientCommandHandler : IRequestHandler<SoftDeletePatientCommand, SoftDeletePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;

            public SoftDeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, IUserService userService)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
                _userService = userService;
            }

            public async Task<SoftDeletePatientResponse> Handle(SoftDeletePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(i => i.Id == request.Id);

                if (patient == null || patient.IsDeleted == true)
                {
                    throw new NotFoundException(PatientsMessages.PatientNotExists);
                }

                await _patientRepository.SoftDeleteAsync(patient);

                if (patient.UserId.HasValue)
                {
                    User? user = await _userService.GetUserByIdAsync(patient.UserId.Value);
                    if (user != null)
                    {
                        user.IsDeleted = true;
                        await _userService.UpdateUserAsync(user);
                    }
                }

                SoftDeletePatientResponse response = _mapper.Map<SoftDeletePatientResponse>(patient);
                return response;
            }
        }
    }
}
