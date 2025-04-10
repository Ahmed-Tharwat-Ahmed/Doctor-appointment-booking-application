namespace DoctorAvailability.Domain.Models
{
    public static class SlotTime
    {
        public static DateTime Of(DateTime time)
        {
            if (time <= DateTime.Now)
                throw new ArgumentException("Slot time must be in future");

            return time;
        }
    }
}
