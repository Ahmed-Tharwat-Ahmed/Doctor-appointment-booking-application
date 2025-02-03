namespace DoctorAvailability.Domain.Models
{
    public class Doctor
    {
        public Doctor(string doctorName)
        {
            Name = DoctorName.Of(doctorName);
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
