using AtrinCode.Core.Domain.Articles.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AtrinCode.Core.Domain.DTOs.Articles
{
    public class EditArticleDTO
    {
        [Display(Name = "شناسه")]
        [Required]  
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]

        public string Title { get; set; }
        [Display(Name = "کلیات")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string ShortDescription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DisplayFormat(HtmlEncode = true)]
        public string Content { get; set; }
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int CategoryId { get; set; }
        public string  ArticleImage { get; set; }
        public IFormFile ArticleImageFile { get; set; }
        public List<FileTable> FileList { get; set; }
        public List<IFormFile> ArticleFile { get; set; }
    }
}
