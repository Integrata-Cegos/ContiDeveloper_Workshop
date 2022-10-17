using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CameraDb.Entities
{
    public partial class Camera
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(64)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("price")]
        public double? Price { get; set; }
    }
}
