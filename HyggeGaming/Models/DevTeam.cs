using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("DevTeam")]
public partial class DevTeam
{
    [Key]
    [Column("DevTeam_ID")]
    public int DevTeamId { get; set; }

    [Column("DevTName")]
    [StringLength(30)]
    [Unicode(false)]
    public string DevTname { get; set; } = null!;

    [InverseProperty("DevTeam")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("DevTeam")]
    public virtual ICollection<TeamManager> TeamManagers { get; set; } = new List<TeamManager>();
}
