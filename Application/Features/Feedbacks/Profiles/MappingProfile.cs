using Application.Features.Doctors.Commands.Create;
using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}
    }
}
