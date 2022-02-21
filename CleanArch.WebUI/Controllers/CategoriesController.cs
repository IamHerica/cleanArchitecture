using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        //Apresenta o formulario
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Recebe os dados do formulario
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            //Validações dos DataAnnotations
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            //ViewModel porque está vindo da web
            var categoryViewModel = await _categoryService.GetById(id);

            if(categoryViewModel == null)return NotFound();

            return View(categoryViewModel);
        }


    }
}
