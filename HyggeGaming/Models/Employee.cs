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

    [Column("EMail")]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<DevTeam> DevTeams { get; set; } = new List<DevTeam>();

    [InverseProperty("Employee")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [ForeignKey("ZipCode")]
    [InverseProperty("Employees")]
    public virtual City ZipCodeNavigation { get; set; } = null!;
}
