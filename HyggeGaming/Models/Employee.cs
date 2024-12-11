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
     
    [Required(ErrorMessage = "FirstName is required")]
    [StringLength(30)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "LastName is required")]
    [StringLength(30)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "ZipCode is required")]
    public int ZipCode { get; set; }

    [Required(ErrorMessage = "Mail is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(50)]
    [Unicode(false)]
    public string Mail { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(30)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "RoleId is required")]
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
