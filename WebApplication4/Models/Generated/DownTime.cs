using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("DownTime")]
public partial class DownTime
{
    [Key]
    [Column("DownTimeID")]
    public int DownTimeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DownTimeText { get; set; } = null!;

    [Column("StopReasonFK")]
    public int StopReasonFk { get; set; }

    [ForeignKey("StopReasonFk")]
    [InverseProperty("DownTimes")]
    public virtual StopReason StopReasonFkNavigation { get; set; } = null!;
}
