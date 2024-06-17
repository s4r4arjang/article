using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.Entities.Articles;
using AtrinCode.Core.Domain.PagingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Contracts.Services.Articles
{
    public interface ICategoryService
    {
        List<DisplayCategoryDTO> GetAll();
        void InsertCategory(CreateCategoryDTO category);
        void EditCategory(EditCategoryDTO category);
        EditCategoryDTO GetCategory(int categoryId);
        void DeleteCategory(int categoryId);
        void ActiveCategory(int id);
        void DeActiveCategory(int id);
        PagingResult<DisplayCategoryDTO> GetCategoryPageList(PagingData PagingData);
    }
}
