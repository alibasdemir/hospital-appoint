using Application.Features.DoctorAvailabilities.Commands.Create;
using Application.Features.DoctorAvailabilities.Constants;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.DoctorAvailabilities.Rules
{
    public class DoctorAvailabilityBusinessRules
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorAvailabilityBusinessRules(IDoctorAvailabilityRepository doctorAvailabilityRepository, IDoctorRepository doctorRepository)
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task DoctorAvailabilityShouldBeExist(int id)
        {
            DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.Id == id);
            if (doctorAvailability == null || doctorAvailability.IsDeleted == true)
            {
                throw new BusinessException(DoctorAvailabilityMessages.DoctorAvailabilityNotExists);
            }

        }
        public async Task DoctorShouldBeExist(int id)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == id);
            if (doctor == null || doctor.IsDeleted == true)
            {
                throw new BusinessException(DoctorAvailabilityMessages.DoctorNotExists);
            }
        }

        public async Task ValidateDoctorAvailability(CreateDoctorAvailabilityCommand request)
        {
            var existingAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.DoctorId == request.DoctorId &&
                                                                                         ((i.StartTime < request.EndTime && i.StartTime >= request.StartTime) ||
                                                                                         (i.EndTime > request.StartTime && i.EndTime <= request.EndTime)));
            if (existingAvailability != null)
            {
                throw new BusinessException(DoctorAvailabilityMessages.TimeSlotAlreadyBooked);
            }
        }
    }
}
