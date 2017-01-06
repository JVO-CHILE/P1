using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class KbcFuncion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int funId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string funNombre { get; set; }

        public virtual ICollection<KbcPerfil> KbcPerfiles { get; set; }

    }
}
