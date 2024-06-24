using Application.Features.Doctors.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;


namespace Application.Features.Doctors.Commands.Update
{
	public class UpdateDoctorCommand : IRequest<UpdateDoctorResponse>, ISecuredRequest, ILoggableRequest
    {
		public int Id { get; set; }
		public string SpecialistLevel { get; set; }
		public int YearsOfExperience { get; set; }
		public string Biography { get; set; }
		public int UserId { get; set; }
		public int DepartmentId { get; set; }

        public string[] RequiredRoles => new[] { Admin, Write, DoctorsOperationClaims.Update };

        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorResponse>
		{
			private readonly IDoctorRepository _doctorRepository;
			private readonly IMapper _mapper;

			public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
			{
				_doctorRepository =	doctorRepository;
				_mapper = mapper;
			}

			public async Task<UpdateDoctorResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
			{
				Doctor? doctor = _mapper.Map<Doctor>(request);

                await _doctorRepository.UpdateAsync(doctor);

                UpdateDoctorResponse response = _mapper.Map<UpdateDoctorResponse>(doctor);
				return response;
			}
		}
	}
}
