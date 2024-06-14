using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Admins.Queries.GetById
{
    public class GetByIdAdminQuery : IRequest<GetByIdAdminResponse>
    {
        public int Id { get; set; }

        public class GetByIdAdminQueryHandler : IRequestHandler<GetByIdAdminQuery, GetByIdAdminResponse>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public GetByIdAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAdminResponse> Handle(GetByIdAdminQuery request, CancellationToken cancellationToken)
            {
                Admin? admin = await _adminRepository.GetAsync(i => i.Id == request.Id,
                    include: source => source.Include(a => a.AdminActions));
                if (admin == null)
                {
                    throw new BusinessException("No such Admin found");
                }

                GetByIdAdminResponse response = _mapper.Map<GetByIdAdminResponse>(admin);
                return response;
            }
        }
    }
}
