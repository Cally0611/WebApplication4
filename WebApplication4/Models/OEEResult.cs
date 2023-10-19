using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class OEEResultShift
    {
        public string ShiftDate { get; set; }

        public DateTime ShiftDatedt
        {
            get
            {
                return Helpers.DateTimeHelper.ConvertSTR_Datedt(ShiftDate); 
            }
        }
        public int ShiftNo { get; set; }

        public int MachineID { get;set; }


        [Column(TypeName = "decimal(4,2)")]
        public decimal OEE { get;set; }
    }
}
