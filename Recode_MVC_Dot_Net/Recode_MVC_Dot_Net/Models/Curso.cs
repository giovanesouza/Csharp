using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Recode_MVC_Dot_Net.Models
{

    [Table("Curso")]

    public class Curso  {
        public int CursoId { get; set; }
        [Display(Name = "Descricao")]

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }


        [Display(Name = "Carca_Horaria")]
        [Required]
        public int CargaHoraria { get; set; }

    }
}