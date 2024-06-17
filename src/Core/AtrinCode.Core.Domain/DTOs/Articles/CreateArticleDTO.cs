using AtrinCode.Core.Domain.Entities.Articles;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AtrinCode.Core.Domain.DTOs.Articles
{
    public class CreateArticleDTO
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage ="{0} را وارد کنید")]
       
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
        public string ArticleImage { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
