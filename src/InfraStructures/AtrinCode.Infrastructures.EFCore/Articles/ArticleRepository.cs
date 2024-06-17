using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Infrastructures.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AtrinCode.Core.Domain.PagingModel;
using AtrinCode.Core.Domain.Articles.Entities;

namespace AtrinCode.Infrastructures.EFCore.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AtrinDbContext _context;
        public ArticleRepository(AtrinDbContext context)
        {
            _context = context;
        }

        public void RemoveArticle(Article article)
        {
            _context.Articles.Remove(article);  
        }

        public bool ExistTitle(string title)
        {
           return _context.Articles.Any(a => a.Title == title);
        }

        public bool ExistTitle(string title, int exceptArticleId)
        {
            return _context.Articles.Any(p=>p.Title == title && p.Id!=exceptArticleId); 
        }

        public Article GetArticle(int articleId)
        {
            return _context.Articles.FirstOrDefault(p => p.Id == articleId);
           
        }

        public DisplayArticleWithFiles GetArticleWithFiles(int articleId)
        {
            //return _context.Articles.FirstOrDefault(p => p.Id == articleId);
            var article = (from p in _context.Articles
                           join e in _context.Files
                           on p.Id equals e.ArticleId
                           where e.ArticleId == articleId
                           select new DisplayArticleWithFiles
                           {
                               Id = p.Id,
                               ArticleImage = p.ArticleImage,
                               Content = p.Content,
                               ShortDescription = p.ShortDescription,
                               Title = p.Title,
                               CategoryId = p.CategoryId,
                               FileList = p.FileList,
                           }).FirstOrDefault();
            return article;
        }

        public List<DisplayArticleDTO> GetArticles()
        {
            

            var articles = (from p in _context.Articles
                            join e in _context.Categories
                             on p.CategoryId equals e.Id
                            select new DisplayArticleDTO
                            {
                                Title = p.Title,
                                Id = p.Id,
                                CategoryTitle = e.Title,
                                ShortDescription = p.ShortDescription,
                                Content = p.Content,
                                ArticleImage=p.ArticleImage,
                                StatusTitle = ((int)p.Status) == 0 ? "دیده نشده" :
                                ((int)p.Status) == 1 ? "در حال بررسی" :
                                ((int)p.Status) == 2 ? "رد شده" :
                                    "تایید شده"
                            }).ToList();

            return articles;    
//            string query = @" select a.Title as Tite , a.ShortDescription as ShortDescription , a.Content as Content ,

//b.Title as CategoryTitle
//, case 
//when a.[Status]= 1 then N'در حال بررسی'
//when a.[Status]= 2 then N'رد شده'
//when a.[Status]= 3 then N'تایید شده'
//when a.[Status]= 0 then N'دیده نشده'
//end as StatusTitle
//from Articles a
//join Categories b on b.Id = a.CategoryId";

//        var res  = _context.Articles.FromSqlRaw(query).ToList().
//                Select(item =>
//            new DisplayArticleDTO
//            {
//             Id=item.Id,
//             Title=item.Title,
//             CategoryTitle=item.CategoryTitle,
//             Content=item.Content,
//             ShortDescription=item.ShortDescription,
//             StatusTitle = item.StatusTitle
//            }).ToList();
           
            //return articles;
            //return _context.Articles.Include(p => p.category).Select(s=>new DisplayArticleDTO()
            //{
            //   ArticleCategory=s.Title,
            //   Title=s.Title,
            //   Detail =s.Detail,
            //   Id=s.Id
            //}).ToList();    
        }

        public void AddArticle(Article article)
        {
           _context.Articles.Add(article);
        }

        public PagingResult<DisplayArticleDTO> GetArticlePagingList(PagingData pagingData)
        {
            var query = (from p in _context.Articles
                                         join e in _context.Categories
                                          on p.CategoryId equals e.Id
                                         select new DisplayArticleDTO
                                         {
                                             Title = p.Title,
                                             Id = p.Id,
                                             CategoryTitle = e.Title,
                                             ShortDescription = p.ShortDescription,
                                             Content = p.Content,
                                             ArticleImage=p.ArticleImage,
                                             StatusTitle = ((int)p.Status) == 0 ? "دیده نشده" :
                                             ((int)p.Status) == 1 ? "در حال بررسی" :
                                             ((int)p.Status) == 2 ? "رد شده" :
                                                 "تایید شده"
                                         });
            var model = new PagingResult<DisplayArticleDTO>();
            model.Paging.TotalItem = query.Count();

            model.Result = query.Skip(pagingData.Skip).Take(pagingData.PageSize).ToArray();
            return model;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
        }

        
        public void SaveArticleFiles(FileTable fileTable)
        {
            _context.Files.Add(fileTable);
        }

        public int GetArticleId(string Title)
        {
            return _context.Articles.Where(p => p.Title == Title).FirstOrDefault().Id;
        }

        //public void DeleteArticle(Article article)
        //{
        //    _context.Articles.Remove(article);
        //}

        //public Article GetArticle(string Title)
        //{
        //    return _context.Articles.Where(p => p.Title == Title).FirstOrDefault();
        //}

        //public Article GetArticle(int id)
        //{
        //    return _context.Articles.Find(id);
        //}

        //public List<DisplayArticleDTO> GetArticles()
        //{
        //    var articles = (from p in _context.Articles
        //                  join e in _context.Categories
        //                  on p.CategoryId equals e.Id
        //                  select new DisplayArticleDTO
        //                  {
        //                      Id=p.Id,
        //                      Title = p.Title,
        //                      Detail=p.Detail,
        //                      ArticleCategory = e.Title
        //                  }).ToList();
        //    return articles;
        //    //return _context.Articles.Include(p => p.category).Select(s=>new DisplayArticleDTO()
        //    //{
        //    //   ArticleCategory=s.Title,
        //    //   Title=s.Title,
        //    //   Detail =s.Detail,
        //    //   Id=s.Id
        //    //}).ToList();    
        //}

        //public bool ExistArticle(Article article)
        //{
        //    var res = _context.Articles.Any(p => p.Title == article.Title && p.Id != article.Id);
        //    if (res != null)
        //        return true;
        //    else return false;
        //}
        //public void InsertArticle(Article article)
        //{
        //    _context.Articles.Add(article);
        //}


        //public int Save()
        //{
        //   return _context.SaveChanges();
        //}

        //public void UpdateArticle(Article article)
        //{
        //     _context.Entry(article).State = EntityState.Modified;
        //}
    }
}
