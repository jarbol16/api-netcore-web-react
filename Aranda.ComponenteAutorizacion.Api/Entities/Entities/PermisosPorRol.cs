using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Aranda.ComponenteAutorizacion.Entities
{
    [Keyless]
    [Table("PermisosPorRol")]
    [Index(nameof(RolId), nameof(PermisoId), Name = "AK_PermisosPorRol", IsUnique = true)]
    public partial class PermisosPorRol
    {
        [Column("rolId")]
        public byte? RolId { get; set; }
        [Column("permisoId")]
        public int? PermisoId { get; set; }

        [ForeignKey(nameof(PermisoId))]
        public virtual Permiso Permiso { get; set; }
        [ForeignKey(nameof(RolId))]
        public virtual Rol Rol { get; set; }
    }
}
