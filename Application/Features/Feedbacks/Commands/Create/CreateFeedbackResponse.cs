using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackResponse
    {
		public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
		public int UserId { get; set; }
	}
}
