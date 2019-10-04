using GestaoDeUsuario.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeUsuario.Infra.Mapeamento
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(k => k.UsuarioId);

            builder.Property(u => u.UsuarioId)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(u => u.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(100)");


            builder.Property(u => u.Senha)
              .HasColumnType("varchar(30)");

            builder.Property(u => u.DataNascimento)
              .HasColumnType("date")
              .IsRequired();

            builder.Property(u => u.Ativo)
             .HasColumnType("bit")
             .IsRequired();

            builder.HasOne(u => u.Sexo)
                .WithOne();

        }
    }
}
