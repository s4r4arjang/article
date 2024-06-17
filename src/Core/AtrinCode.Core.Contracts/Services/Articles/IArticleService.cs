using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Contracts.Services.Articles
{
    public interface IArticleService
    {
        List<DisplayArticleDTO> GetAll();
        int InsertArticle(CreateArticleDTO article);
        EditArticleDTO GetArticle(int articleId);//     yeki dige ghrar bood bara show besazi
        DisplayArticleWithFiles GetArticleWithFiles(int articleId);
        DisplayArticleDetailsDTO GetArticleDetails(int articleId);
        string GetArticleImage(int articleId);
        void EditArticle(EditArticleDTO article);  
        void DeleteArticle(int articleId);
        public void AcceptArticle(int id);
        public void RejectArticle(int id);
        public void PendingArticle(int id);

        PagingResult<DisplayArticleDTO> GetArticlePageList(PagingData pagingData);
        void SaveArticleFiles(FileTable fileTable);
    }
}
