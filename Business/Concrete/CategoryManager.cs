using DataAccess.Concrete.Repositories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return repository.GetAll();
        }
        public void Add(Category category)
        {
            if (category.Name == "" || category.Name.Length <= 3 || category.Description == "" || category.Name.Length > 50)
            {
                // error message
            }
            else
            {
                repository.Add(category);
            }

        }
    }
}
