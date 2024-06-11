using Application.Features.AdminActions.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
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

                await _userRepository.AddAsync(user);
                CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
                return response;
            }
        }
    }
}

