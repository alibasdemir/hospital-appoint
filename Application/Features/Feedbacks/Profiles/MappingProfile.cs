using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Commands.Delete;
using Application.Features.Feedbacks.Commands.SoftDelete;
using Application.Features.Feedbacks.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Feedbacks.Profiles
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
			CreateMap<Feedback, CreateFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, CreateFeedbackResponse>().ReverseMap();
			
			CreateMap<Feedback, UpdateFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, UpdateFeedbackResponse>().ReverseMap();

			CreateMap<Feedback, DeleteFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, DeleteFeedbackResponse>().ReverseMap();

			CreateMap<Feedback, SoftDeleteFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, SoftDeleteFeedbackResponse>().ReverseMap();
		}
    }
}
