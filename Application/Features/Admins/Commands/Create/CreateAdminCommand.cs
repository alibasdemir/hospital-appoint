//using Application.Repositories;
//using Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Features.Admins.Commands.Create
//{
//    public class CreateAdminCommand : IRequest<CreateAdminResponse>
//    {
//        public Admin Admin { get; set; }

//        public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreateAdminResponse>
//        {
//            private readonly IAdminRepository _adminRepository;

//            public CreateAdminCommandHandler(IAdminRepository adminRepository)
//            {
//                _adminRepository = adminRepository;
//            }

//            public async Task<CreateAdminResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
//            {
//                Admin admin = new()
//                {
//                    Admin = request.Admin,
//                };
//                await _adminRepository.AddAsync(admin);
//                return new CreateAdminResponse() { Admin = admin.Admin };
//            }
//        }
//    }
//}
