﻿using Application.Features.Users.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Hashing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ChangePasswordResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public ChangePasswordCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);

                if (user == null || user.IsDeleted == true)
                {
                    throw new NotFoundException(UsersMessages.UserNotExists);
                }

                bool passwordControl = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

                if (!passwordControl) 
                {
                    throw new BusinessException("Your password is wrong.");
                }

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userRepository.UpdateAsync(user);

                ChangePasswordResponse response = _mapper.Map<ChangePasswordResponse>(request);
                return response;
            }
        }
    }
}
