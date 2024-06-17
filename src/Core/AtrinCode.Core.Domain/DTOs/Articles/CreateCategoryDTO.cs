using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.DTOs.Articles
{
    public class CreateCategoryDTO
    {
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
    }
}
