using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Manager.Domain.Entities;

namespace Manager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) // Mapeando a classe User
        {
            // Minha tabela no banco chamará User
            builder.ToTable("User");

            // Mapeando o Id como PK (HasKey)
            builder.HasKey(x => x.Id);

            // Mapeando o Id
            // tipo dele como BIGINT (ele é long na classe)
            // auto-increment (UseMySqlIdentityColumn) 
            builder.Property(x => x.Id)
            .UseMySqlIdentityColumn()
            .HasColumnType("BIGINT");

            // Mapeando o nome
            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(80)");

            // Mapeando o email
            builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(180)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(180)");

            // Mapeando a senha
            builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(30)");
        }
    }
}