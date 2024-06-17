using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Contracts.Services.Articles;
using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.DomainServices.Articles;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;

namespace AtrinCode.Core.ApplicationServices.Articles
{

  


    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IValidationCategory _validationCategory;

        public CategoryService(ICategoryRepository repo , 
            IValidationCategory validationCategory)
        {
            _repo = repo;
            _validationCategory = validationCategory;
        }

        public void InsertCategory(CreateCategoryDTO category)
        {

            _repo.AddCategory(new Category(category.Title, _validationCategory));
            
                _repo.Save();
         
        }

        public void DeleteCategory(int categoryId)
        {
            var res = _repo.GetCategory(categoryId);
            res.Delete(_validationCategory);
            _repo.RemoveCategory(res);
            _repo.Save();
        }

        public List<DisplayCategoryDTO> GetAll()
        {
            return _repo.GetCategories().Select(p=> new DisplayCategoryDTO()
            {
                Id= p.Id,
                Title= p.Title,
                IsActive = p.IsActive
            }).ToList();    
        }

        public EditCategoryDTO GetCategory(int categoryId)
        {
           var res= _repo.GetCategory(categoryId);
            return new EditCategoryDTO() { Id = res.Id, Title = res.Title };
        }

        public void EditCategory(EditCategoryDTO category)
        {
            var res = _repo.GetCategory(category.Id);
            res.Edit(category.Title, _validationCategory);
            _repo.UpdateCategory(res);
            _repo.Save();

        }

        public void ActiveCategory (int id )
        {
            var res =_repo.GetCategory(id);
            res.Active();
            _repo.Save();
        }

        public void DeActiveCategory(int id)
        {
            var res = _repo.GetCategory(id);
            res.DeActive();
            _repo.Save();
        }


        public PagingResult<DisplayCategoryDTO> GetCategoryPageList(PagingData PagingData)
        {
            return _repo.GetCategoryPageList(PagingData);
        }
    }
}
