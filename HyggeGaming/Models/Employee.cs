using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("Employee_ID")]
    public int EmployeeId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    public int ZipCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Mail { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("Role_ID")]
    public int RoleId { get; set; }

    [Column("DevTeam_ID")]
    public int? DevTeamId { get; set; }

    [ForeignKey("DevTeamId")]
    [InverseProperty("Employees")]
    public virtual DevTeam? DevTeam { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Employees")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("ZipCode")]
    [InverseProperty("Employees")]
    public virtual City ZipCodeNavigation { get; set; } = null!;
}
