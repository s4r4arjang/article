using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.DTOs.Articles
{
    public class DisplayCategoryDTO
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "عنوان دسته بندی")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
