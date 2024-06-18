//using Application.Repositories;
//using AutoMapper;
//using Domain.Entities;
//using MediatR;
//using System.Security.Cryptography;
//using System.Text;

//namespace Application.Features.Auth.Commands.Register
//{
//    public class RegisterCommand : IRequest
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }

//        public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
//        {
//            private readonly IMapper _mapper;
//            private readonly IUserRepository _userRepository;

//            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository)
//            {
//                _mapper = mapper;
//                _userRepository = userRepository;
//            }

//            public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
//            {
//                User user = _mapper.Map<User>(request);

//                using HMACSHA512 hmac = new();
            
//                user.PasswordSalt = hmac.Key;
//                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                
//                await _userRepository.AddAsync(user);
//            }
//        }
//    }
//}
