using Project_One.Gateway;
using Project_One.Interface;
using Project_One.Models;
using Project_One.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public string Create(Category category)
        {
            category.Slug = Slug.make(category.Name);
            var result = CategoryGateway.AddCategory(category);
            if(result != 0)
            {
                return "Category Added Successfull";
            }
            return "Somthing Wrong! Please try again";
        }

        public string Delete(int id)
        {
            int row = 0;
            row = CategoryGateway.Delete(id);
            if(row != 0)
            {
                return "Category Delete Successfull";
            }
            return "Somthing Wrong! Please try again";
        }

        public Category Get(int id)
        {
            return CategoryGateway.GetCategoryById(id);
        }

        public List<Category> GetAll()
        {
            return CategoryGateway.GetAllCategory();
        }

        public string Update(int id, Category category)
        {
            category.Slug = Slug.make(category.Name);
            var result = CategoryGateway.Update(category,id);
            if (result != 0)
            {
                return "Category Added Successfull";
            }
            return "Somthing Wrong! Please try again";
        }
    }
}
