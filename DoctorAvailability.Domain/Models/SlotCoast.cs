using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.Domain.Models
{
    public static class SlotCoast
    {
        public static double Of( double coast)
        {
            if (coast < 0)
                throw new ArgumentException("Slot Coast must by equal or greter than 0");

            return coast;
        }
    }
}
