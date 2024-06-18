using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Create
{
    public class CreateAdminCommand : IRequest<CreateAdminResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreateAdminResponse>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public CreateAdminCommandHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<CreateAdminResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
            {
                Admin admin = _mapper.Map<Admin>(request);
                
                await _adminRepository.AddAsync(admin);
                CreateAdminResponse response = _mapper.Map<CreateAdminResponse>(admin);
                return response;
            }
        }
    }
}
