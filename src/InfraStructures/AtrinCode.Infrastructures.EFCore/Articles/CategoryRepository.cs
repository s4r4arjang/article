using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.DomainServices.Articles;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;
using AtrinCode.Infrastructures.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Infrastructures.EFCore.Articles
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AtrinDbContext _context;

        public CategoryRepository(AtrinDbContext context)
        {
            _context = context;
        }

        public void RemoveCategory(Category articleCategory)
        {
            _context.Categories.Remove(articleCategory);
        }

        public bool ExistTitle(int exceptCategoryId, string title)
        {
           return _context.Categories.Any(c => c.Title == title && c.Id!= exceptCategoryId);
        }

        public bool ExistTitle( string title)
        {
            return _context.Categories.Any(c => c.Title == title);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == categoryId);
        }

        public void AddCategory(Category category)
        {
           _context.Categories.Add(category);
            
        }
        public bool NotAllowDelete(int categoryId)
        {
            return _context.Articles.Any(c => c.CategoryId== categoryId);
            //var article = (from d in _context.Articles
            //              where d.CategoryId == id
            //             select d ).FirstOrDefault();
                                      
            //if (article != null)
            //    return false;
            //else return true;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public PagingResult<DisplayCategoryDTO> GetCategoryPageList(PagingData pagingData)
        {

            IQueryable<Category> query = _context.Categories;
            PagingResult<DisplayCategoryDTO> res = new PagingResult<DisplayCategoryDTO>();

            res.Paging.TotalItem = query.Count();
     res.Result=       query.Skip(pagingData.Skip).Take(pagingData.PageSize).Select(p=>new 
          DisplayCategoryDTO()
          {
               Id = p.Id,
               Title = p.Title,
               IsActive = p.IsActive
          }).ToList();

            return res;

        }
    }
}
