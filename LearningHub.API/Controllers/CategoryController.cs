using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet]
        [Route("GetAllCategories")]

        public List<Category> GetAllCategories()

        {
            return _categoryService.GetAllCategories();
        }


        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public void GetCategoryById(int id)

        {
            _categoryService.GetCategoryById(id);
        }


        [HttpPost]
        [Route("CreateCategory")]
        public void CreateCategory(Category category)
        {
        
            _categoryService.CreateCategory(category);

        }


        [HttpPut]
        [Route("UpdateCategory")]

       public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }


        [HttpDelete]
        [Route("DeleteCategory/{id}")]
       public void DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
        }

    }
}
