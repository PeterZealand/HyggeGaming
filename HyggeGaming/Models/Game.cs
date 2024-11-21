using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("Game")]
public partial class Game
{
    [Key]
    [Column("Game_ID")]
    public int GameId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string GameName { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string GameType { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string DevelopmentStage { get; set; } = null!;

    [Column("Assignment_ID")]
    public int? AssignmentId { get; set; }

    [ForeignKey("AssignmentId")]
    [InverseProperty("Games")]
    public virtual Assignment? Assignment { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<DevTeam> DevTeams { get; set; } = new List<DevTeam>();
}
