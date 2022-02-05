using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{

    //Garantindo que a classe não poderá ser herdada(sealed)
    //Herdando de entity pois o Id é unico para ser usado tanto em product quanto em category
    public sealed class Product : Entity
    {        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Propriedade de navegação
        //O EF precisa disso para quando gerar o Banco de dados, entender que precisa criar uma
        //tabela de relação entre Product e Category
        //Será entendida como uma chave estrangeira
        //Não é private pq nao daz parte do modelo de domínio
        public int CategoryId { get; set; }

        //Propriedade que relaciona meu produto com o tipo Category
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 charecters is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 6,
                "Invalid description, too short, minimum 6 charecters is required");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid link image, too long, maxium 250 characters");           

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }        
    }
}
