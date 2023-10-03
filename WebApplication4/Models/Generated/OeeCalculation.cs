using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("OeeCalculation")]
public partial class OeeCalculation
{
    [Key]
    [Column("OeeID")]
    public int OeeId { get; set; }

    public DateTime Oeedatetime { get; set; }

    public int Downtime { get; set; }

    public int Totalpieces { get; set; }

    public int Rejectpieces { get; set; }

    public int Notasave { get; set; }

    public int ShiftNo { get; set; }

    [StringLength(10)]
    public string ShiftDate { get; set; } = null!;
}
