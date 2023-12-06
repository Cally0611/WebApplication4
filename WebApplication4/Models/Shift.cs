namespace WebApplication4.Models
{
    public class Shift
    {
        public TimeSpan FirstShift { get;set; }
        public TimeSpan SecondShift { get;set; }

        public TimeSpan SharpMidnight { get;set; }

        public TimeSpan CurrTime 
        {
           get { return DateTime.Now.TimeOfDay; }
        }
        
        public DateTime DateBasedonShift { get; set; }

        public int ShiftType { get; set; }
    }
}
