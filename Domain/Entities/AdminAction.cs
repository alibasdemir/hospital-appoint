using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminAction : Entity<int>
    {
        public ActionType ActionType { get; set; }
        public string ActionDescription { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
