using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackCommand : IRequest<CreateFeedbackResponse>
    {
		public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;

            public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<CreateFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback feedback = _mapper.Map<Feedback>(request);

                await _feedbackRepository.AddAsync(feedback);
                CreateFeedbackResponse response = _mapper.Map<CreateFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
