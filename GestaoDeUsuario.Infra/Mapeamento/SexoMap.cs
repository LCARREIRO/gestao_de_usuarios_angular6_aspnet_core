using GestaoDeUsuario.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeUsuario.Infra.Mapeamento
{
    public class SexoMap : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.HasKey(k => k.SexoId);

            builder.Property(u => u.SexoId)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(u => u.Descricao)
               .HasColumnType("varchar(15)")
               .IsRequired();
        }
    }
}
