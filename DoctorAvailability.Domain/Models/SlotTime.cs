using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.Domain.Models
{
    public static class SlotTime
    {
        public static DateTime Of(DateTime time)
        {
            if (time <= DateTime.Now)
                throw new InvalidDataException("Slot time must be in future");

            return time;
        }
    }
}
