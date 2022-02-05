using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //Representa o contexto da minha categoria
        private ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }


        //Sempre que for async tem que ser task pois retorna uma task de Category
        //Task não retorna um objeto, retorna uma tarefa que tem um retorno após finalizada
        public async Task<Category> Create(Category category)
        {
            //Salvando a categoria na memoria
            _categoryContext.Add(category);
            
            //Salvando a categoria no banco de dados
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            //Movendo do contexto
            _categoryContext.Remove(category);

            //Salvando no banco de dados
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {

            //Atualiza a categoria
            _categoryContext.Update(category);

            //Salvando a categoria no banco de dados
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}