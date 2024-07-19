using Application.Features.Doctors.Constants;
using Application.Features.Doctors.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;

namespace Application.Features.Doctors.Commands.Delete
{
    public class DeleteDoctorCommand : IRequest<DeleteDoctorResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, DoctorsOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, DeleteDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;
            private readonly DoctorBusinessRules _doctorBusinessRules;

            public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules doctorBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _doctorBusinessRules = doctorBusinessRules;
            }

            public async Task<DeleteDoctorResponse> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                await _doctorBusinessRules.DoctorShouldBeExist(request.Id);

                await _doctorRepository.DeleteAsync(doctor);

                DeleteDoctorResponse response = _mapper.Map<DeleteDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
