using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class TotalPieces
    {
        [Key]
        [Column("ActionID")]
        public int ActionID { get; set; }
       
       public DateTime TimeStamp { get; set; }

     
       public int Machine { get; set; }

        public int LocalActionId { get; set; }

        public DateTime ActionTimeStamp { get; set; }

    }
}
