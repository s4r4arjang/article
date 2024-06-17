using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.DomainServices.Articles;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;

namespace AtrinCode.Core.Contracts.Repositories.Articles
{
    // baghie ro dorost kon
    public interface ICategoryRepository
    {
        PagingResult<DisplayCategoryDTO> GetCategoryPageList(PagingData PagingData);
        List<Category> GetCategories();
        void AddCategory(Category category);
        Category GetCategory(int categoryId);
        bool ExistTitle(int exceptCategoryId, string title);
        bool ExistTitle(string title);
        void UpdateCategory(Category category);
        void RemoveCategory(Category articleCategory);
        bool NotAllowDelete(int categoryId);
        int Save();
    }
}
