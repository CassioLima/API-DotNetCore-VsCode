using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manutencao.Models
{
    [Table("Tipo")]
    public class Tipo{

        public Tipo(string nome)
        {
            this.Nome = nome;
        }

        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(50, ErrorMessage= "O Tag deve conter entre 4 e 50 caracteres" )]
        [MinLength(4, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]        
        public string Nome { get; set; }

        
    }
}