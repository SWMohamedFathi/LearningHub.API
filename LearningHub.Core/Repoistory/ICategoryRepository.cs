using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repoistory
{
    public interface ICategoryRepository
    {
            List<Category> GetAllCategories();
            void CreateCategory(Category category);
            void UpdateCategory(Category category);
            void DeleteCategory(int categoryId);
            Category GetCategoryById(int categoryId);
        
    }
}
