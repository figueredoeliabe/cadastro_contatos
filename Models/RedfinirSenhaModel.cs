using System.ComponentModel.DataAnnotations;


namespace cadastro_contatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Você precisa digitar o login correto")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Você precisa digitar um endereço de email")]
        [EmailAddress(ErrorMessage = "Digite um endereço de email válido")]
        public string Email {get; set; }
    }
}