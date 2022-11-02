using cadastro_contatos.Models;
using System.Collections.Generic;

namespace cadastro_contatos.Repositorio
{
    public interface IContatoRepositorio
    {
         List<ContatoModel> BuscarTodos();
         ContatoModel ListarPorId(int id);
         ContatoModel Adicionar(ContatoModel contato);
         ContatoModel Alterar(ContatoModel contato);
         bool Apagar(int id);
         
    }
}