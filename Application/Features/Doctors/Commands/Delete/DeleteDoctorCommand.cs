using Application.Features.Doctors.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Commands.Delete
{
    public class DeleteDoctorCommand : IRequest<DeleteDoctorResponse>
    {
        public int Id { get; set; }

        public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, DeleteDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<DeleteDoctorResponse> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                if (doctor == null)
                {
                    throw new NotFoundException(DoctorsMessages.DoctorNotExists);
                }

                await _doctorRepository.DeleteAsync(doctor);

                DeleteDoctorResponse response = _mapper.Map<DeleteDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
