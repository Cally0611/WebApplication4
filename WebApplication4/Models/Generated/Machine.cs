using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("Machine")]
public partial class Machine
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MachineName { get; set; } = null!;

    [InverseProperty("Machine")]
    public virtual ICollection<AllMachine> AllMachines { get; set; } = new List<AllMachine>();

    [InverseProperty("Machine")]
    public virtual ICollection<OeeCalculationAll> OeeCalculationAlls { get; set; } = new List<OeeCalculationAll>();

    [InverseProperty("OeeMachineNavigation")]
    public virtual ICollection<OeeDetailsAll> OeeDetailsAlls { get; set; } = new List<OeeDetailsAll>();
}
