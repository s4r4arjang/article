using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.DTOs.Articles
{
    public  class DisplayArticleDetailsDTO
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "کلیات")]
        public string ShortDescription { get; set; }
        [Display(Name = "جزئیات")]
        public string Content { get; set; }

        public string ArticleImage { get; set; }
    }
}
