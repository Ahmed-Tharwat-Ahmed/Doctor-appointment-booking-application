namespace DoctorAvailability.Domain.Models
{
    public static class DoctorName
    {
        public static string Of(string name)
        {
            return string.IsNullOrEmpty(name) ? throw new ArgumentException("Doctor Name can not empty") : name;
        }
    }
}
