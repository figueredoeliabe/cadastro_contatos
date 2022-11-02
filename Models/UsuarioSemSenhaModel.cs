using cadastro_contatos.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace cadastro_contatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digit um nome de usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login desejado")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Você precisa digitar um endereço de e-mail")]
        [EmailAddress(ErrorMessage= "O endereço de e-mail informado não é válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Você precisa definir o tipo de perfil")]
        public PerfilEnum? Perfil { get; set; }
    }
}