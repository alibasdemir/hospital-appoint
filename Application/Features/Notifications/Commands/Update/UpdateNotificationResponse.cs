using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Commands.Update
{
    public class UpdateNotificationResponse
    {
		public NotificationType Type { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
	}
}
