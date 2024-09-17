using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCRUD.Data.Map;

/**
 * Fazendo o mapeamento objeto relacional
 */
public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.UsuarioId);

        // Relations
        builder.HasOne(x => x.Usuario);

    }
}