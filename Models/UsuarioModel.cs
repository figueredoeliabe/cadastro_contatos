using cadastro_contatos.Enums;
using System.ComponentModel.DataAnnotations;
using System;
using cadastro_contatos.Helper;

namespace cadastro_contatos.Models
{
    public class UsuarioModel
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
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao{ get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
            
        }
    }
}