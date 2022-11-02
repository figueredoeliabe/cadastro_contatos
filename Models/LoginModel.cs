using System.ComponentModel.DataAnnotations;


namespace cadastro_contatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Você precisa digitar o login correto")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha {get; set; }
    }
}