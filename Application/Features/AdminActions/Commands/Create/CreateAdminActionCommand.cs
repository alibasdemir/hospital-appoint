﻿using Application.Repositories;
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
        public ActionType Type { get; set; }
        public string ActionDescription { get; set; }

        public class CreateAdminActionCommandHandler : IRequestHandler<CreateAdminActionCommand, CreateAdminActionResponse>
        {

            private readonly IAdminActionRepository _adminActionRepository;

            public CreateAdminActionCommandHandler(IAdminActionRepository adminActionRepository)
            {
                _adminActionRepository = adminActionRepository;
            }

            public async Task<CreateAdminActionResponse> Handle(CreateAdminActionCommand request, CancellationToken cancellationToken)
            {
                AdminAction adminAction = new()
                {
                    AdminId = request.AdminId,
                    Type = request.Type,
                    ActionDescription = request.ActionDescription,
                };
                await _adminActionRepository.AddAsync(adminAction);
                return new CreateAdminActionResponse() 
                { 
                    AdminId = adminAction.AdminId, 
                    Type = adminAction.Type, 
                    ActionDescription = adminAction.ActionDescription};
                }
        }
    }
}
