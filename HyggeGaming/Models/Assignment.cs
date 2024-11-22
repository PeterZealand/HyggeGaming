using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("Assignment")]
public partial class Assignment
{
    [Key]
    [Column("Assignment_ID")]
    public int AssignmentId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string AssignmentName { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("Game_ID")]
    public int GameId { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("Assignments")]
    public virtual Game Game { get; set; } = null!;
}
