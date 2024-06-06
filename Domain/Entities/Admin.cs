using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<AdminAction> AdminActions { get; set; }
    }
}
