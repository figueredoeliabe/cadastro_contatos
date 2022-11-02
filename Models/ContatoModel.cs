using System.ComponentModel.DataAnnotations;

namespace cadastro_contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set;}
        [Required(ErrorMessage = "Você precisa digitar um nome para o contato")]
        public string Nome { get; set;}
        [EmailAddress(ErrorMessage = "Você digitou um endereço de e-mail inválido")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Você precisa digitar um número de telefone")]
        [Phone(ErrorMessage= "Você digitou um telefone com formato inválido")]
        public string Telefone { get; set;}
    }
}
