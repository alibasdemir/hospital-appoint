using Application.Features.SupportRequests.Constants;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SupportRequests.Rules
{
    public class SupportRequestBusinessRules
    {
        private readonly ISupportRequestRepository _supportRequestRepository;

        public SupportRequestBusinessRules(ISupportRequestRepository supportRequestRepository)
        {
            _supportRequestRepository = supportRequestRepository;
        }

        public async Task SupportRequestShouldBeExist(int id)
        {
            SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == id);
            if (supportRequest == null)
            {
                throw new BusinessException(SupportRequestsMessages.SupportRequestNotExists);
            }
        }

        public async Task SupportRequestDeleteControl(int id)
        {
            SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == id);
            if (supportRequest == null || supportRequest.IsDeleted == true)
            {
                throw new BusinessException(SupportRequestsMessages.SupportRequestNotExists);
            }
        }
    }
}
