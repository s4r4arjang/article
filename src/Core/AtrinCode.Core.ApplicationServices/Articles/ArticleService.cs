using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Contracts.Services.Articles;
using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.Entities.Articles.DomainContract;
using AtrinCode.Core.Domain.Exceptions;
using AtrinCode.Core.Domain.PagingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.ApplicationServices.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _Repo;
        private readonly IValidationArticle _validationArticle;

        public ArticleService(IArticleRepository repo , IValidationArticle validationArticle)
        {
            _Repo = repo;
            _validationArticle = validationArticle;
        }

        public int InsertArticle(CreateArticleDTO article)
        {
           
            _Repo.AddArticle(new Article(article.Title, article.ShortDescription, article.Content,
              article.CategoryId, _validationArticle , article.ArticleImage));
            
            _Repo.Save();

            return _Repo.GetArticleId(article.Title);
        }

        public void DeleteArticle(int articleId)
        {
            var res = _Repo.GetArticle(articleId);
            _Repo.RemoveArticle(res);
            _Repo.Save();
        }

        public void AcceptArticle(int id )
        {
            var res = _Repo.GetArticle(id);
            res.AcceptedArticle();
            _Repo.Save();   
        }

        public void RejectArticle(int id)
        {
            var res = _Repo.GetArticle(id);
            res.RejectArticle();
            _Repo.Save();
        }

        public void PendingArticle(int id)
        {
            var res = _Repo.GetArticle(id);
            res.PendingArticle();
            _Repo.Save();
        }

        public PagingResult<DisplayArticleDTO> GetArticlePageList(PagingData pagingData)
        {
          return _Repo.GetArticlePagingList(pagingData);
        }
        public List<DisplayArticleDTO> GetAll()
        {
            return _Repo.GetArticles();
        }

        public EditArticleDTO GetArticle(int articleId)
        {
            var res = _Repo.GetArticle(articleId);
            return new EditArticleDTO()
            {
                Title = res.Title,
                CategoryId = res.CategoryId,
                Id = res.Id,
                ArticleImage = res.ArticleImage,
                ShortDescription = res.ShortDescription,
                Content = res.Content
                //Details = res.Details

            };
        }

        public DisplayArticleWithFiles GetArticleWithFiles(int articleId)
        {
            return _Repo.GetArticleWithFiles(articleId);
           
        }

        public DisplayArticleDetailsDTO GetArticleDetails(int articleId)
        {
            var res = _Repo.GetArticle(articleId);
            var model = new DisplayArticleDetailsDTO()
            {
                Id = res.Id,
                ArticleImage = res.ArticleImage,
                Content = res.Content,
                Title = res.Title,
                ShortDescription = res.ShortDescription
            };
            res.PendingArticle();
            _Repo.Save();
            return model;
        }

        public string GetArticleImage(int articleId)
        {
            return _Repo.GetArticle(articleId).ArticleImage;
        }

        public void EditArticle(EditArticleDTO article)
        {
            var res = _Repo.GetArticle(article.Id);
            res.Edit(article.Title, article.ShortDescription, article.Content,
              article.CategoryId, _validationArticle , article.ArticleImage);
            _Repo.UpdateArticle(res);
            _Repo.Save();
        }

        public void SaveArticleFiles(FileTable fileTable)
        {
            _Repo.SaveArticleFiles(fileTable);
            _Repo.Save();
        }
    }
}
