using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Interface
{
    public interface ICategoryRepository
    {
        public string Create(Category category);
        public Category Get(int id);
        public List<Category> GetAll();
        public string Update(int id, Category category);
        public string Delete(int id);

    }
}
