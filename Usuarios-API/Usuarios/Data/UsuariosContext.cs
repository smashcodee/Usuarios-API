using Microsoft.EntityFrameworkCore;
using Usuarios.Model;

namespace Usuarios.Data
{
    public class UsuariosContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {
            
        }
    }
}
