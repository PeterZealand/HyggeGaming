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

    [Required(ErrorMessage = "Title is required")]
    [StringLength(30)]
    [Unicode(false)]
    public string GameName { get; set; } = null!;

    [Required(ErrorMessage = "Game genre is required")]
    [StringLength(30)]
    [Unicode(false)]
    public string GameType { get; set; } = null!;

    [Required(ErrorMessage = "Developmental stage is required")]
    [StringLength(30)]
    [Unicode(false)]
    public string DevelopmentStage { get; set; } = null!;

    [InverseProperty("Game")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [InverseProperty("Game")]
    public virtual ICollection<TeamManager> TeamManagers { get; set; } = new List<TeamManager>();
}
