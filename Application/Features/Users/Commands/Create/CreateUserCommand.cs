using Application.Features.AdminActions.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>, ILoggableRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);

                using HMACSHA512 hmac = new();
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                await _userRepository.AddAsync(user);
                CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
                return response;
            }
        }
    }
}

