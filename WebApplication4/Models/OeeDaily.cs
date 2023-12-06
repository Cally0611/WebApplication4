using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using WebApplication4.Helpers;

namespace WebApplication4.Models
{
    public partial class OeeDaily
    {

        public DateTime Target_Date { get; set; }
        //public int MachineID { get; set; }

        public string MachineName { get; set; }
        public string Job_Name1 { get; set; }

        public string ParentReasonCode_FullDay { get; set; }

        public DateTime? Oeedatetime { get; set; }

        public int? Downtime { get; set; }

        public int? Uptime { get; set; }

        public int? Totalpieces { get; set; } 

        public int? Rejectpieces { get; set; }

        public int? Notasave { get; set; }

        public int? Waste { get; set; }

        public int? ShiftNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ShiftDate { get; set; }

        [Column("MachineID")]
        public int MachineId { get; set; }

        public virtual Machine Machine { get; set; } = null!;

        public decimal? Availability 
        {
            get
            {
                return new OEESettings().CalculateAvailability(Uptime, Downtime);
            }
        
        
        }

        public decimal? Performance
        {
            get
            {
                return new OEESettings().CalculatePerformance(Uptime, Totalpieces);
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

        public decimal? OEEAveragePercentage { get; set; }
    }
}
