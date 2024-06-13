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

namespace Application.Features.AdminActions.Commands.Create
{
    public class CreateAdminActionCommand : IRequest<CreateAdminActionResponse>
    {
        public int AdminId { get; set; }
        public ActionType ActionType { get; set; }
        public string ActionDescription { get; set; }

        public class CreateAdminActionCommandHandler : IRequestHandler<CreateAdminActionCommand, CreateAdminActionResponse>
        {

            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public CreateAdminActionCommandHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<CreateAdminActionResponse> Handle(CreateAdminActionCommand request, CancellationToken cancellationToken)
            {
                AdminAction adminAction = _mapper.Map<AdminAction>(request);
                await _adminActionRepository.AddAsync(adminAction);
                CreateAdminActionResponse response = _mapper.Map<CreateAdminActionResponse>(adminAction);
                return response;
            }
        }
    }
}
