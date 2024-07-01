﻿using Application.Features.Doctors.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

            public SoftDeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteDoctorResponse> Handle(SoftDeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                if (doctor == null || doctor.IsDeleted == true)
                {
                    throw new NotFoundException(DoctorsMessages.DoctorNotExists);
                }

                await _doctorRepository.SoftDeleteAsync(doctor);

                SoftDeleteDoctorResponse response = _mapper.Map<SoftDeleteDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
