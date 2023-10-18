using System.ComponentModel.DataAnnotations;

namespace Usuarios.Data.Dto
{
    public class CreateUsuarioDto
    { // ---------------------------NOME------------------------------
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        // ---------------------------EMAIL-----------------------------
        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(150, ErrorMessage = "O tamanho do email não pode execeder 150 caracteres")]
        public string Email { get; set; }
        // ---------------------------STATUS------------------------------
        [Required(ErrorMessage = "o status é obrigatório")]
        public bool status { get; set; }
    }
}
