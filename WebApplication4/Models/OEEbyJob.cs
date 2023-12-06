using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using WebApplication4.Helpers;

namespace WebApplication4.Models
{
    public class OEEbyJob
    {
        public DateTime CurrentDate { get; set; }
        public int TotalNoofDays
        {
            get
            {
                return JobRunDates.Length;
            }
        }

        public string JobName { get; set; }

        public int TotalDownTime { get; set; }

        public int OeeMachine { get;set; }

        public int Totalpieces { get;set; }

        public int[] ListofMachines { get; set; }

        public DateTime[] JobRunDates { get; set; }

        public DateTime[] Test { get;set; }

        public decimal? Availability
        {
            get
            {
                return new OEESettings().CalculateAvailability((TotalNoofDays*24*60), TotalDownTime);
            }
        }

        public decimal? Performance
        {
            get
            {
                return new OEESettings().CalculatePerformance((TotalNoofDays * 24 * 60), Totalpieces);
            }
        }

        public decimal? Quality
        {
            get
            {
                return Convert.ToDecimal(100.00);
            }
        }
        //public decimal Quality { get; set;}

        public decimal? OEE
        {
            get
            {
                return new OEESettings().CalculateOEEPercentage(Availability, Quality, Performance);
            }
        }
    }
}
