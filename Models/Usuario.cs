using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manutencao.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(8, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]
        [MinLength(4, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(8, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]
        [MinLength(4, ErrorMessage = "O Tag deve conter entre 4 e 8 caracteres")]
        public string Password { get; set; }

        public string Role {get; set;}

        
    }
}