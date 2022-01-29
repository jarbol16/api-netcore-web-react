using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Aranda.ComponenteAutorizacion.Entities
{
    [Keyless]
    [Table("Usuario")]
    [Index(nameof(RolId), Name = "AK_Rol", IsUnique = true)]
    public partial class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("contrasena")]
        [StringLength(50)]
        public string Contrasena { get; set; }
        [Column("personaId")]
        public int? PersonaId { get; set; }
        [Column("rolId")]
        public byte? RolId { get; set; }

        [ForeignKey(nameof(PersonaId))]
        public virtual Persona Persona { get; set; }
        [ForeignKey(nameof(RolId))]
        public virtual Rol Rol { get; set; }

        [NotMapped]
        public List<string> Permisos { get; set; }
    }
}
