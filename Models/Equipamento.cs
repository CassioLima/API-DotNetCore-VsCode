using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manutencao.Models
{
    [Table("Equipamento")]
    public class Equipamento
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(8, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]
        [MinLength(4, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]
        public string Tag { get; set; }

        public Tipo Tipo { get; set; }

        public int TipoId { get; set; }
    }
}