using System.ComponentModel.DataAnnotations;

namespace cadastro_contatos.Models
{
    public class AlterarSenhaModel
    {   
        
        public int Id { get; set;}
        [Required(ErrorMessage = "Digite sua senha atual")]
        public string SenhaAtual { get; set;}
        [Required(ErrorMessage = "Digite sua nova senha")]
        public string NovaSenha { get; set;}
        [Required(ErrorMessage = "Digite confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "Senhas não conferem")]
        public string ConfirmarNovaSenha { get; set;}
    }
}