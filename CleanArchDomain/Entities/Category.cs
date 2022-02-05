using CleanArch.Domain.Validation;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {       
        public string Name { get; private set; }        

        public Category(string name)
        {
            ValidateDomain(name);
        }

        //Pede Id para ser usado quando o EF for popular a tabela
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        //Uma categoria poderá ter 1 ou mais produtos
        //Propriedade de navegação
        //Sabe que é prop de navegação pq o tipo que está apontando não pode ser mapeado
        public ICollection<Product> Products { get; set; }

        //Método de validação do nome
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3 ,"Invalid name, too short, minimum 3 charecters is required");
            Name = name;
        }
    }
}
