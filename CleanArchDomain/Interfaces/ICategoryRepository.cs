using CleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {

        //IEnumerable retorna uma lista enumerada
        //Task porque desejamos trabalhar de forma assincrona
        Task<IEnumerable<Category>> GetCategories();

        //O ? significa que pode receber um valor nulo(O nome disso é açucar sintático)
        Task<Category> GetById(int? id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
}
