using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Update
{
    public class UpdateFeedbackCommand : IRequest<UpdateFeedbackResponse>
    {
		public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, UpdateFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;

            public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<UpdateFeedbackResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback feedback = _mapper.Map<Feedback>(request);

                await _feedbackRepository.UpdateAsync(feedback);
                UpdateFeedbackResponse response = _mapper.Map<UpdateFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
