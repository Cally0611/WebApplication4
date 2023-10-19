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

        public string StopReasonStart { get; set; } = null!;

        public string StopReasonEnd { get; set; } = null!;

        public string Stop_MReason { get; set; } = null!;

        public string Stop_SReason { get; set; } = null!;
    }

}
