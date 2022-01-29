using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Aranda.ComponenteAutorizacion.Entities
{
    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Column("direccion")]
        [StringLength(80)]
        public string Direccion { get; set; }
        [Column("telefono")]
        [StringLength(10)]
        public string Telefono { get; set; }
        [Column("email")]
        [StringLength(60)]
        public string Email { get; set; }
        [Column("edad")]
        public int? Edad { get; set; }
    }
}
