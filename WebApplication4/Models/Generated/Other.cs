using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("Other")]
public partial class Other
{
    [Key]
    [Column("OtherID")]
    public int OtherId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string OtherText { get; set; } = null!;

    [Column("StopReasonFK")]
    public int StopReasonFk { get; set; }

    [ForeignKey("StopReasonFk")]
    [InverseProperty("Others")]
    public virtual StopReason StopReasonFkNavigation { get; set; } = null!;
}
