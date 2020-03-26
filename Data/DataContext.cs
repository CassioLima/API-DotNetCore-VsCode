using Microsoft.EntityFrameworkCore;
using Manutencao.Models;

namespace Manutencao.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option)
            :base(option)
        {

        }

        public DbSet<Equipamento> Equipamentos { get; set; }

        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


    }
}