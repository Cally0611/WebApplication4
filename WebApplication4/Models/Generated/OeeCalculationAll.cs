using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("OeeCalculationAll")]
public partial class OeeCalculationAll
{
    [Key]
    [Column("OeeCalculationID")]
    public int OeeCalculationId { get; set; }

    [Column("OeeLocalID")]
    public int OeeLocalId { get; set; }

    public DateTime Oeedatetime { get; set; }

    public int Downtime { get; set; }

    public int Uptime { get; set; }

    public int Totalpieces { get; set; }

    public int Rejectpieces { get; set; }

    public int Notasave { get; set; }

    public int? Waste { get; set; }

    public int? ShiftNo { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ShiftDate { get; set; }

    [Column("MachineID")]
    public int MachineId { get; set; }

    [Column("SPOperation")]
    [StringLength(3)]
    [Unicode(false)]
    public string Spoperation { get; set; } = null!;

    public DateTime InsUpdTimeStamp { get; set; }

    [ForeignKey("MachineId")]
    [InverseProperty("OeeCalculationAlls")]
    public virtual Machine Machine { get; set; } = null!;
}
