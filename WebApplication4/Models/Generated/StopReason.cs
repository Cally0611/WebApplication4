using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

public partial class StopReason
{
    [Key]
    [Column("StopReason_ID")]
    public int StopReasonId { get; set; }

    [Column("StopReason_Text")]
    [StringLength(200)]
    public string StopReasonText { get; set; } = null!;

    [Column("StopReason_Type")]
    [StringLength(50)]
    [Unicode(false)]
    public string StopReasonType { get; set; } = null!;

    [InverseProperty("StopReasonFkNavigation")]
    public virtual ICollection<Cleaning> Cleanings { get; set; } = new List<Cleaning>();

    [InverseProperty("StopReasonFkNavigation")]
    public virtual ICollection<DownTime> DownTimes { get; set; } = new List<DownTime>();

    [InverseProperty("StopReasonFkNavigation")]
    public virtual ICollection<MachineRepair> MachineRepairs { get; set; } = new List<MachineRepair>();

    [InverseProperty("StopReasonFkNavigation")]
    public virtual ICollection<Machinestop> Machinestops { get; set; } = new List<Machinestop>();

    [InverseProperty("StopReasonFkNavigation")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    [InverseProperty("StopReasonFkNavigation")]
    public virtual ICollection<Other> Others { get; set; } = new List<Other>();
}
