using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        //Conexão com o bando de dados usando EF
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options) { }


        //Mapeamento ORM
        //Mapeando a propriedade Category para a tabela Categories
        //Mapeando a propriedade Product para a tabela Products
        public DbSet<Product> Products { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        //Configurações das entidades
        //Permite configurar o modelo usando as configurações feitas no ApplicationDbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Dizendo p meu arquivo vasculhar meu arquivo de contexto, identificar minhas entidades Products e Categories 
            //E como minha EntitiesConfig herda de IEntityConfiguration, faz com que ele encontre minhas configurações
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
