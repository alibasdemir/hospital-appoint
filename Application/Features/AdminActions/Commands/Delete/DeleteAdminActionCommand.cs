using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Commands.Delete
{
    public class DeleteAdminActionCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteAdminActionCommandHandler : IRequestHandler<DeleteAdminActionCommand>
        {
            private readonly IAdminActionRepository _adminActionRepository;

            public DeleteAdminActionCommandHandler(IAdminActionRepository adminActionRepository)
            {
                _adminActionRepository = adminActionRepository;
            }

            public async Task Handle(DeleteAdminActionCommand request, CancellationToken cancellationToken)
            {
                AdminAction adminAction = await _adminActionRepository.GetAsync(i => i.Id == request.Id);

                if (adminAction == null)
                {
                    throw new ArgumentException("No such Admin Action found");
                }

                await _adminActionRepository.DeleteAsync(adminAction);
            }
        }
    }
}
