using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminAction : Entity
    {
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public string ActionType { get; set; }
        public string ActionDescription { get; set; }
    }
}
