using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //A propriedade Id dessa entidade precisa ser a chave primaria
            builder.HasKey(t => t.Id);
            
            //A propriedade nome tem tamanho maximo de 100 caracts e é requirida
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            
            //A propriedade preço tem precisão máxima de:
            builder.Property(p => p.Price).HasPrecision(10, 2);

            //Configurando um relacionamento onde uma categoria tem muitos produtos e categoryId é minha chave estrangeira
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
        }
    }
}
