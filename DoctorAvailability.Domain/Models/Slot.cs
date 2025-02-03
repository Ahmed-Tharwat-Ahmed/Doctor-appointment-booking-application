namespace DoctorAvailability.Domain.Models
{
    public class Slot
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Time { get; set; }
        public bool IsReserved { get; set; }
        public double Coast { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        private Slot(Doctor doctor, DateTime time, double coast, bool isReserved)
        {
            Doctor = doctor;
            Time = time;
            Coast = coast;
            IsReserved = isReserved;
        }
        public Slot()
        {

        }


        public static Slot CreateNewSlot(Doctor doctor, DateTime time, double coast)
        {
            return new Slot(doctor, SlotTime.Of(time), SlotCoast.Of(coast), false);
        }
    }
}
