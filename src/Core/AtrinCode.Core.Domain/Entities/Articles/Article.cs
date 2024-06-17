using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Core.Domain.Entities.Articles.DomainContract;
using AtrinCode.Core.Domain.Enum;
using AtrinCode.Core.Domain.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AtrinCode.Core.Domain.Entities.Articles
{
    //  why isnt there namespace
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [DisplayFormat(HtmlEncode = true)]
        public string Content { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ArticleStatus Status { get; set; }
        public List<FileTable> FileList { get; set; }
        public string ArticleImage { get; set; }



        private Article()
        {
        }

        public Article(string title, IValidationArticle validationArticle)
        {
            if (validationArticle.ExistTitle(title))
                throw new DuplicateException("عنوان تکراری میباشد");
            Title = title;
            Status = ArticleStatus.New;
        }

        public Article(string title, string shortDescription, string content,
              int categoryId, IValidationArticle validationArticle, string articleImage)
        {
            if (validationArticle.ExistTitle(title))
                throw new DuplicateException("عنوان تکراری میباشد");
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Status = ArticleStatus.New;
            CategoryId = categoryId;
            ArticleImage = articleImage;
        }

        public void Edit(string title, string shortDescription, string content,
             int categoryId, IValidationArticle validationArticle, string articleImage)
        {
            if (validationArticle.ExistTitle(Id, title))
                throw new DuplicateException("عنوان تکراری میباشد");
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Status = ArticleStatus.New;
            CategoryId = categoryId;
            ArticleImage = articleImage;
        }

        public void AcceptedArticle()
            {
            Status = ArticleStatus.Accepted;
            }
        public void RejectArticle()
        {
            Status = ArticleStatus.Rejected;
        }

        public void PendingArticle()
        {
            if (Status==ArticleStatus.New)
            Status = ArticleStatus.Pending;
        }

    }
}
