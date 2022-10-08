using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void DeleteCategory(int CatId);
        void UpdateCategory(Category category);
    }
}
