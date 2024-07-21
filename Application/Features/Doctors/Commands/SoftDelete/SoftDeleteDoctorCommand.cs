using Application.Features.Doctors.Constants;
using Application.Features.Doctors.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;

namespace Application.Features.Doctors.Commands.SoftDelete
{
    public class SoftDeleteDoctorCommand : IRequest<SoftDeleteDoctorResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, DoctorsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteDoctorCommandHandler : IRequestHandler<SoftDeleteDoctorCommand, SoftDeleteDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;
            private readonly DoctorBusinessRules _doctorBusinessRules;

            public SoftDeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules doctorBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _doctorBusinessRules = doctorBusinessRules;
            }

            public async Task<SoftDeleteDoctorResponse> Handle(SoftDeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                await _doctorBusinessRules.DoctorDeleteControl(request.Id);

                await _doctorRepository.SoftDeleteAsync(doctor);

                await _doctorBusinessRules.SoftDeleteDoctorWithUser(request.Id);

                SoftDeleteDoctorResponse response = _mapper.Map<SoftDeleteDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
