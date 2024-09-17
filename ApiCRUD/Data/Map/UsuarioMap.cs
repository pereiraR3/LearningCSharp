using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCRUD.Data.Map;

/**
 * Fazendo o mapeamento objeto relacional 
 */
public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
{
    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(150);

        // Relations    
        builder.HasMany(x => x.Tarefas)
           .WithOne(x => x.Usuario)
           .HasForeignKey(x => x.UsuarioId); 

    }
}