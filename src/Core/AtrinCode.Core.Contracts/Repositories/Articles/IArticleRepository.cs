using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Contracts.Repositories.Articles
{
    public interface IArticleRepository
    {
        List<DisplayArticleDTO> GetArticles();
        Article GetArticle(int articleId);
        DisplayArticleWithFiles GetArticleWithFiles(int articleId);
        void AddArticle (Article article);   
        void UpdateArticle (Article article);   
        void RemoveArticle (Article article);
        bool ExistTitle(string title);
        bool ExistTitle(string title , int exceptArticleId);
        PagingResult<DisplayArticleDTO> GetArticlePagingList(PagingData pagingData);
        int GetArticleId(string Title);
        void SaveArticleFiles(FileTable fileTable);
        int Save();

    }
}
