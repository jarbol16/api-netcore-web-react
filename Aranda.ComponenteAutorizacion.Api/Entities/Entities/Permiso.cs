using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Aranda.ComponenteAutorizacion.Entities
{
    [Table("Permiso")]
    public partial class Permiso
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(20)]
        public string Nombre { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(80)]
        public string Descripcion { get; set; }
    }
}
