using NivelAccessDate_DBFirst.Interfaces;

using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class CategoriesAccessor(ETailorEntities _db) : ICategoriesAccessor
    {
        private readonly ETailorEntities _db = _db;

        public List<LibrarieModele.Category> GetCategories()
        {
            return _db.Categories.Select(MapToLibrarieModel).ToList();
        }

        public LibrarieModele.Category GetCategoryById(int categoryId)
        {
            var repositoryCategory = _db.Categories.Find(categoryId);
            return repositoryCategory != null ? MapToLibrarieModel(repositoryCategory) : null;
        }

        public void UpdateCategory(LibrarieModele.Category updatedCategory)
        {
            var existingCategory = _db.Categories.Find(updatedCategory.Category_Id);
            if (existingCategory != null)
            {
                UpdateRepositoryModel(existingCategory, updatedCategory);
                _db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Category with ID {updatedCategory.Category_Id} not found.");
            }
        }

        public void DeleteCategory(LibrarieModele.Category category)
        {
            var existingCategory = _db.Categories.Find(category.Category_Id);

            if (existingCategory != null)
            {
                _db.Categories.Remove(existingCategory);
                _db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Category with ID {category.Category_Id} not found.");
            }
        }

        public void AddCategory(LibrarieModele.Category newCategory)
        {
            var repositoryCategory = MapToRepositoryModel(newCategory);
            _db.Categories.Add(repositoryCategory);
            _db.SaveChanges();
        }

        private LibrarieModele.Category MapToLibrarieModel(Repository_DBFirst.Category repositoryCategory)
        {
            return repositoryCategory != null ? new LibrarieModele.Category
            {
                Category_Id = repositoryCategory.category_id
            } : null;
        }

        private void UpdateRepositoryModel(Category existingCategory, LibrarieModele.Category updatedCategory)
        {
            existingCategory.category_id = updatedCategory.Category_Id;
        }

        private Category MapToRepositoryModel(LibrarieModele.Category category)
        {
            return category != null ? new Category
            {
                category_id = category.Category_Id
            } : null;
        }
    }
}
