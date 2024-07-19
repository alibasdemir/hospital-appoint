using Application.Features.Doctors.Constants;
using Application.Repositories;
using Application.Services.UserService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Doctors.Rules
{
    public class DoctorBusinessRules
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserService _userService;

        public DoctorBusinessRules(IDoctorRepository doctorRepository, IUserService userService)
        {
            _doctorRepository = doctorRepository;
            _userService = userService;
        }

        public async Task UserShouldBeExist(int id)
        {
            User? user = await _userService.GetUserByIdAsync(id);
            {
                if (user == null || user.IsDeleted == true)
                {
                    throw new BusinessException(DoctorsMessages.UserNotExists);
                }
            }
        }

        public async Task DoctorShouldBeExist(int id)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == id);
            if (doctor == null)
            {
                throw new BusinessException(DoctorsMessages.DoctorNotExists);
            }
        }

        public async Task DoctorDeleteControl(int id)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == id);
            if(doctor == null || doctor.IsDeleted == true)
            {
                throw new BusinessException(DoctorsMessages.DoctorNotExists);
            }
        }

        public async Task SoftDeleteDoctorWithUser(int id)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == id);
            if(doctor.UserId.HasValue)
            {
                User? user = await _userService.GetUserByIdAsync(doctor.UserId.Value);
                if (user != null)
                {
                    user.IsDeleted = true;
                    await _userService.UpdateUserAsync(user);
                }
            }
        }
    }
}
