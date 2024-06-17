using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Domain.Entities.Articles.DomainContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.ApplicationServices.Articles.DomainService
{
    public class ValidationArticle : IValidationArticle
    {
        private readonly IArticleRepository _articleRepository;

        public ValidationArticle(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        public bool ExistTitle(int exceptArticleId, string title)
        {
            return _articleRepository.ExistTitle(title, exceptArticleId);
        }

        public bool ExistTitle(string title)
        {
            return _articleRepository.ExistTitle(title);
        }
    }
}
