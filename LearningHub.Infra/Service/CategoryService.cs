using LearningHub.Core.Data;
using LearningHub.Core.Repoistory;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository CategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return CategoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return CategoryRepository.GetCategoryById(id);

        }

        public void CreateCategory(Category category)
        {
             CategoryRepository.CreateCategory(category);

        }

         public void UpdateCategory(Category category)
        {
            CategoryRepository.UpdateCategory(category);

        }
       public void DeleteCategory(int categoryId)

        {
            CategoryRepository.DeleteCategory(categoryId);

        }


    }
}
