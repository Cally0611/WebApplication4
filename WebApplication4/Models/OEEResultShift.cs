using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Helpers;

namespace WebApplication4.Models
{
    public class OEEResultShift
    {
        public DateTime Target_Date { get; set; }
       

        public int MachineID { get; set; }
        public string Job_Name1 { get; set; }

        public string ParentReasonCode_FullDay { get; set; }

        public string ParentReasonCode_Shift { get; set; }

        public int Target_Shift { get; set; }
        public int Timetillnow { get; set; }

        public int? Downtime { get; set; }

        public int? Uptime
        {
            get
            {
                return Timetillnow - Downtime;
            }
        }


        public int? Totalpieces { get; set; }

        public decimal? ActualAvailability
        {
            get
            {
                return new OEESettings().CalculateAvailability(Uptime, Downtime);
            }


        }

        public decimal? ActualPerformance
        {
            get
            {
                return new OEESettings().CalculatePerformance(Uptime, Totalpieces);
            }
        }

        public decimal? ActualQuality
        {
            get
            {
                return Convert.ToDecimal(100.00);
            }
        }
      
        public decimal? ActualOEE
        {
            get
            {
                return new OEESettings().CalculateOEEPercentage(ActualAvailability, ActualQuality, ActualPerformance);
            }
        }


        public decimal? TargetAvailability
        {
            get
            {
                return Convert.ToDecimal(100.00);
            }


        }

        public decimal? TargetPerformance
        {
            get
            {
                return new OEESettings().CalculatePerformance(720, Target_Shift);
            }
        }

        public decimal? TargetQuality
        {
            get
            {
                return Convert.ToDecimal(100.00);
            }
        }

        public decimal? TargetOEE
        {
            get
            {
                return new OEESettings().CalculateOEEPercentage(TargetAvailability, TargetQuality, TargetPerformance);
            }
        }


    }
}
