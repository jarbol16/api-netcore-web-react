using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Aranda.ComponenteAutorizacion.Entities
{
    [Table("Rol")]
    public partial class Rol
    {
        [Key]
        [Column("id")]
        public byte Id { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("descripcion")]
        [StringLength(250)]
        public string Descripcion { get; set; }
    }
}
