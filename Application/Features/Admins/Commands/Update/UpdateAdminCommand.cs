using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Update
{
    public class UpdateAdminCommand : IRequest<UpdateAdminResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdateAdminResponse>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public UpdateAdminCommandHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAdminResponse> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
            {
                Admin? admin = await _adminRepository.GetAsync(i => i.Id == request.Id);

                if (admin == null)
                {
                    throw new BusinessException("No such Admin found");
                }

                _mapper.Map(request, admin);
                
                await _adminRepository.UpdateAsync(admin);

                UpdateAdminResponse response = _mapper.Map<UpdateAdminResponse>(admin);
                return response;
            }
        }
    }
}
