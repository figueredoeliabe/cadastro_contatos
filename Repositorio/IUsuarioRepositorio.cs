using cadastro_contatos.Models;
using System.Collections.Generic;

namespace cadastro_contatos.Repositorio
{
    public interface IUsuarioRepositorio
    {   
         UsuarioModel BuscarPorLogin(string login);
         UsuarioModel BuscarEmailLogin (string email, string login);
         List<UsuarioModel> BuscarTodos();
         UsuarioModel ListarPorId(int id);
         UsuarioModel Adicionar(UsuarioModel usuario);
         UsuarioModel Atualizar(UsuarioModel usuario);
         UsuarioModel AlterarSenha (AlterarSenhaModel alterarSenhaModel);
         bool Apagar(int id);
         
    }
}