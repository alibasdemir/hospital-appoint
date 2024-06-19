using Core.DataAccess;
using Core.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseUser
    {
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
    }
}
