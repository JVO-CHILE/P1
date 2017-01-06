using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class KbcPersona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int perId { get; set; }

        [Required]
        [Display(Name = "Rut")]        
        public int perRut { get; set; }
        
        [Required]
        [Display(Name = "DV")]        
        public char perDv { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string perNombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [DataType(DataType.Text)]
        public string perPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        [DataType(DataType.Text)]
        public string perMaterno { get; set; }

        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string perMail { get; set; }

        public virtual ICollection<KbcUsuario> KbcUsuarios { get; set; }
    }
}
