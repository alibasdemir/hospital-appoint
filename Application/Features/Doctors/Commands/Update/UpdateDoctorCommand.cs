using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Doctors.Commands.Update
{
	public class UpdateDoctorCommand : IRequest<UpdateDoctorResponse>
	{
		public string SpecialistLevel { get; set; }
		public int YearsOfExperience { get; set; }
		public string Biography { get; set; }
		public int UserId { get; set; }
		public int DepartmentId { get; set; }

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
				Doctor doctor = _mapper.Map<Doctor>(request);
				await _doctorRepository.UpdateAsync(doctor);

				UpdateDoctorResponse response = _mapper.Map<UpdateDoctorResponse>(doctor);
				return response;
			}
		}
	}
}
