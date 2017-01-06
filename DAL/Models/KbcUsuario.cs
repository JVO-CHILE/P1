using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class KbcUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usuId { get; set; }

        public int perfId { get; set; }
        public int perId { get; set; }

        [Required]
        [Display(Name = "usuario")]
        public string usuUserName { get; set; }

        [Required]
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        public string usuClave { get; set; }

        public bool usuTipo { get; set; }
        public bool usuVigente { get; set; }

        public virtual KbcPersona KbcPersona { get; set; }
        public virtual KbcPerfil KbcPerfil { get; set; }
    }
}
