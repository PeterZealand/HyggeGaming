using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

[Table("City")]
public partial class City
{
    [Key]
    public int ZipCode { get; set; }

    [Column("City")]
    [StringLength(50)]
    [Unicode(false)]
    public string City1 { get; set; } = null!;

    [InverseProperty("ZipCodeNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
