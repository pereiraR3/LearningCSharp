using ApiCRUD.Data.Map;
using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Data

{
    public class ApiCRUDDBContext : DbContext
    {

        public ApiCRUDDBContext(DbContextOptions<ApiCRUDDBContext> options) : base  (options)
        {
            
        }
        
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}