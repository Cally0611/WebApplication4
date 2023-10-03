using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("Cleaning")]
public partial class Cleaning
{
    [Key]
    [Column("CleaningID")]
    public int CleaningId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CleaningText { get; set; } = null!;

    [Column("StopReasonFK")]
    public int StopReasonFk { get; set; }

    [ForeignKey("StopReasonFk")]
    [InverseProperty("Cleanings")]
    public virtual StopReason StopReasonFkNavigation { get; set; } = null!;
}
