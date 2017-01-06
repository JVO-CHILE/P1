using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class KbcPerfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int perfId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string perfNombre { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string perfDescripcion { get; set; }

        public virtual ICollection<KbcUsuario> KbcUsuarios { get; set; }
        public virtual ICollection<KbcFuncion> KbcFunciones { get; set; }


    }
}
