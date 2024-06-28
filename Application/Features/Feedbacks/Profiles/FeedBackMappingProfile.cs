using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Commands.Delete;
using Application.Features.Feedbacks.Commands.SoftDelete;
using Application.Features.Feedbacks.Commands.Update;
using Application.Features.Feedbacks.Queries.GetById;
using Application.Features.Feedbacks.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;

namespace Application.Features.Feedbacks.Profiles
{
	public class FeedBackMappingProfile : Profile
	{
        public FeedBackMappingProfile()
        {
			CreateMap<Feedback, CreateFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, CreateFeedbackResponse>().ReverseMap();
			CreateMap<Feedback, UpdateFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, UpdateFeedbackResponse>().ReverseMap();
			CreateMap<Feedback, DeleteFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, DeleteFeedbackResponse>().ReverseMap();
			CreateMap<Feedback, SoftDeleteFeedbackCommand>().ReverseMap();
			CreateMap<Feedback, SoftDeleteFeedbackResponse>().ReverseMap();
			CreateMap<Feedback, GetByIdFeedbackQuery>().ReverseMap();
			CreateMap<Feedback, GetByIdFeedbackResponse>().ReverseMap();
			CreateMap<Feedback, GetListFeedbackQuery>().ReverseMap();
			CreateMap<Feedback, GetListFeedbackResponse>().ReverseMap();
			CreateMap<IPaginate<Feedback>, GetListResponse<GetListFeedbackResponse>>().ReverseMap();
		}
    }
}
