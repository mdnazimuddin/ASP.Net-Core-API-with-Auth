using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Interface
{
    public interface IProductRepository
    {
        public string Create(Product product);
        public Product Get(int id);
        public List<Product> GetAll();
        public string Update(int id, Product product);
        public string Delete(int id);
    }
}
