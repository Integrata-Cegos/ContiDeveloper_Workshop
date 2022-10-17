using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Television.Db.Entities
{
    public partial class Television
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("PRICE")]
        public double? Price { get; set; }
    }
}
