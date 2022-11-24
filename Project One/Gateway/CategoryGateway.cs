using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Gateway
{
    public class CategoryGateway : DbGateway
    {
        public static int AddCategory(Category category)
        {
            int row = 0;
            var query = "INSERT INTO [Category] (Name, Slug) VALUES('" + category.Name + "', '" + category.Slug + "')";
            row = GetExecute(query);
            return row;
        }
        public static Category GetCategoryById(int id)
        {
            var query = "SELECT * FROM [Category] WHERE Id = '" + id + "'";
            return GetQueryFirst<Category>(query);
        }
        public static List<Category> GetAllCategory()
        {
            var query = "SELECT * FROM [Category]";
            return GetQueryList<Category>(query);
        }
        public static int Update(Category category,int id)
        {
            int row = 0;
            var query = "UPDATE Category SET Name = '"+ category.Name+ "', Slug = '"+ category.Slug + "' WHERE Id = '"+id+"' ";
            row = GetExecute(query);
            return row;
        }
        public static int Delete(int id)
        {
            int row = 0;
            var query = "DELETE FROM Category WHERE id='"+id+"'";
            row = GetExecute(query);
            return row;
        }
    }
}
