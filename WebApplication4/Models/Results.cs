using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Results
    {
        public int ID { get; set; }

        public string MachineName { get; set; } = null!;

        public DateTime Target_Date { get; set; }

        public string? JobName1 { get; set; }
        public int? OeeMachine { get; set; }

        public DateTime StopReasonStart { get; set; }

        public DateTime StopReasonEnd { get; set; }

        public string Stop_MReason { get; set; } = null!;

        public string Stop_SReason { get; set; } = null!;

        public int DiffinTime
        {
            get
            {
                return Convert.ToInt32(StopReasonEnd.Subtract(StopReasonStart).TotalMinutes);
            }
        }
    }

}
