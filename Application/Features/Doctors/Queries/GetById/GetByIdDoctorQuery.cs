using Application.Features.Doctors.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Queries.GetById
{
    public class GetByIdDoctorQuery : IRequest<GetByIdDoctorResponse>
    {
        public int Id { get; set; }

        public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQuery, GetByIdDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetByIdDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdDoctorResponse> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                if (doctor == null || doctor.IsDeleted == true)
                {
                    throw new NotFoundException(DoctorsMessages.DoctorNotExists);
                }

                GetByIdDoctorResponse response = _mapper.Map<GetByIdDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
