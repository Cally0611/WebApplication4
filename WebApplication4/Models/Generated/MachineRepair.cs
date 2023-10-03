using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("MachineRepair")]
public partial class MachineRepair
{
    [Key]
    [Column("MachineRepairID")]
    public int MachineRepairId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MachineRepairText { get; set; } = null!;

    [Column("StopReasonFK")]
    public int StopReasonFk { get; set; }

    [ForeignKey("StopReasonFk")]
    [InverseProperty("MachineRepairs")]
    public virtual StopReason StopReasonFkNavigation { get; set; } = null!;
}
