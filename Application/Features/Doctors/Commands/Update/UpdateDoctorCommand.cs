using Application.Features.Doctors.Constants;
using Application.Features.Doctors.Rules;
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
        public string[] RequiredRoles => new[] { Admin, DoctorsOperationClaims.Update };
        public int Id { get; set; }
		public string SpecialistLevel { get; set; }
		public int YearsOfExperience { get; set; }
		public string Biography { get; set; }
		public int UserId { get; set; }
		public int DepartmentId { get; set; }

        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorResponse>
		{
			private readonly IDoctorRepository _doctorRepository;
			private readonly IMapper _mapper;
			private readonly DoctorBusinessRules _doctorBusinessRules;

            public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules doctorBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _doctorBusinessRules = doctorBusinessRules;
            }

            public async Task<UpdateDoctorResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
			{
				Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

				await _doctorBusinessRules.DoctorDeleteControl(request.Id);

				_mapper.Map(request, doctor);

                await _doctorRepository.UpdateAsync(doctor);

                UpdateDoctorResponse response = _mapper.Map<UpdateDoctorResponse>(doctor);
				return response;
			}
		}
	}
}
