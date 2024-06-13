using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Admins.Commands.Delete
{
    public class DeleteAdminCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand>
        {
            private readonly IAdminRepository _adminRepository;

            public DeleteAdminCommandHandler(IAdminRepository adminRepository)
            {
                _adminRepository = adminRepository;
            }

            public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
            {
                Admin? admin = await _adminRepository.GetAsync(i => i.Id == request.Id);

                if (admin == null)
                    throw new BusinessException("No such Admin found");
                

                await _adminRepository.DeleteAsync(admin);
            }
        }
    }
}
