namespace DoctorAvailability.Domain.Models
{
    public class Slot
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Time { get; set; }
        public double Coast { get; set; }
        public bool IsReserved { get; set; }

        public string DoctorId { get; set; }
        public string DoctorName { get; set; }

        private Slot(DateTime time, double coast, string doctorId, string doctorName, bool isReserved)
        {
            Time = time;
            Coast = coast;
            DoctorId = doctorId;
            DoctorName = doctorName;
            IsReserved = isReserved;
        }

        public Slot()
        {

        }

        public static Slot CreateNewSlot(DateTime time, double coast, string doctorId, string doctorName)
        {
            return new Slot(SlotTime.Of(time), SlotCoast.Of(coast), doctorId, doctorName, false);
        }
    }
}
