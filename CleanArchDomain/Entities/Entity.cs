namespace CleanArch.Domain.Entities
{
    //Classe modelo/base para compartilhar recursos comuns entre entidades de dominio
    //Usada para reunir toda a lógica comum em um só lugar
    //Classe abstrata pois não permite implementação
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
