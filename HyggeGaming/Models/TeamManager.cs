using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("TeamManager")]
public partial class TeamManager
{
    [Key]
    [Column("TM_ID")]
    public int TmId { get; set; }

    [Column("DevTeam_ID")]
    public int DevTeamId { get; set; }

    [Column("Game_ID")]
    public int GameId { get; set; }

    [ForeignKey("DevTeamId")]
    [InverseProperty("TeamManagers")]
    public virtual DevTeam DevTeam { get; set; } = null!;

    [ForeignKey("GameId")]
    [InverseProperty("TeamManagers")]
    public virtual Game Game { get; set; } = null!;
}
