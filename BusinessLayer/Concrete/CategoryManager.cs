using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        IGenericDal<Category> _category;

        public CategoryManager(IGenericDal<Category> category)
        {
            _category = category;
        }

        public void AddCategory(Category category)
        {
            _category.Insert(category);
            
        }

        public void DeleteCategory(Category category)
        {

            _category.Delete(category);
        }

        public List<Category> GetAllCategories()
        {
            return _category.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _category.GetById(id);
        }

        public void UpdateCategory(Category category)
        {
            _category.Update(category);
        }
    }
}
