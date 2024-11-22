using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("Role")]
public partial class Role
{
    [Key]
    [Column("Role_ID")]
    public int RoleId { get; set; }

    [Column("Role")]
    [StringLength(30)]
    [Unicode(false)]
    public string Role1 { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
