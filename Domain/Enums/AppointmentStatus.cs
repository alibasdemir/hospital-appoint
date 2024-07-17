using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum AppointmentStatus
    {
        None = 0,
        Cancelled = 1,
        Completed = 2,
        Available = 3,
        Booked = 4
    }
}
