using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Software.Service;

[Table("SOFTWARE")]
public partial class Software
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }
    [Column("NAME")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Name { get; set; }
    [Column("PRICE")]
    public double? Price { get; set; }
}