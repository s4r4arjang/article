using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Domain.DomainServices.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.ApplicationServices.Articles.DomainService
{
    public class ValidationCategory : IValidationCategory
    {
        private readonly ICategoryRepository _repository;
        public ValidationCategory(ICategoryRepository repository)
        {
          this._repository = repository;
        }
        public bool ExistTitle(int exceptCategoryId, string title)
        {
            return _repository.ExistTitle(exceptCategoryId, title); 
        }

        public bool ExistTitle(string title)
        {
            return _repository.ExistTitle(title);
        }

        public bool NotAllowDelete(int categoryId)
        {
            return _repository.NotAllowDelete(categoryId); 
        }
    }
}
