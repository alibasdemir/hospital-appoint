using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Commands.Update
{
    public class UpdateAdminActionResponse
    {
        public int Id { get; set; }
        public ActionType ActionType { get; set; }
        public string ActionDescription { get; set; }
        public int AdminId { get; set; }
    }
}
