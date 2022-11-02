using cadastro_contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastro_contatos.Data
{

    //Parâmetros de Banco de dados
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :
            base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}