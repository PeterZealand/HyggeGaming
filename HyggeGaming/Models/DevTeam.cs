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

    [Column("Employee_ID")]
    public int EmployeeId { get; set; }

    [Column("Game_ID")]
    public int GameId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("DevTeams")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("GameId")]
    [InverseProperty("DevTeams")]
    public virtual Game Game { get; set; } = null!;
}
