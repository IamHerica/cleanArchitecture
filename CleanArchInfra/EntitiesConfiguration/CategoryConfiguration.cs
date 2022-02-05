using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category>builder)
        {
            //A propriedade Id dessa entidade precisa  ser a chave primaria
            builder.HasKey(t => t.Id);

            //Padronizando que o nome é requirido e seu tamanho maximo é de 100 caracteres
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            //Popular a tabela assim que gerar a Migration
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
                );
        }
    }
}
