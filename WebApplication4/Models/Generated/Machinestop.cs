using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("Machinestop")]
public partial class Machinestop
{
    [Key]
    [Column("MachinestopID")]
    public int MachinestopId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MachinestopText { get; set; } = null!;

    [Column("StopReasonFK")]
    public int StopReasonFk { get; set; }

    [ForeignKey("StopReasonFk")]
    [InverseProperty("Machinestops")]
    public virtual StopReason StopReasonFkNavigation { get; set; } = null!;
}
