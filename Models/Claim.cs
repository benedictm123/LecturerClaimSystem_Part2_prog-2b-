namespace ClaimSystem.Models
{
    public class Claim
    {
        public string ID { get; set; }
        public string AdditionalNotes { get; set; }
        public string LecturerID { get; set; }
        public DateTime Date { get; set; }
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public double Total;
        public string Status { get; set; }
    }
}