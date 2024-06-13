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

namespace Application.Features.AdminActions.Commands.Update
{
    public class UpdateAdminActionCommand : IRequest<UpdateAdminActionResponse>
    {
        public int Id { get; set; }
        public ActionType ActionType { get; set; }
        public string ActionDescription { get; set; }
        public int AdminId { get; set; }

        public class UpdateAdminActionCommandHandler : IRequestHandler<UpdateAdminActionCommand, UpdateAdminActionResponse>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public UpdateAdminActionCommandHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAdminActionResponse> Handle(UpdateAdminActionCommand request, CancellationToken cancellationToken)
            {
                AdminAction adminAction = await _adminActionRepository.GetAsync(i => i.Id == request.Id);
                
                if (adminAction == null)
                {
                    throw new ArgumentException("No such Admin Action found");
                }

                _mapper.Map(request, adminAction);

                UpdateAdminActionResponse response = _mapper.Map<UpdateAdminActionResponse>(adminAction);
                return response;
            }
        }
    }
}
