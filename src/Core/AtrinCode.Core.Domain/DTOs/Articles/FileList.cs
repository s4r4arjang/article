using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.DTOs.Articles
{
    public class FileList
    {
        [Display(Name ="ردیف")]
        public int PicsID { get; set; }
        [Display(Name = "نام فایل")]
        public string PicsName { get; set; }
        [Display(Name = "عکس")]
        public string PicsUrl { get; set; }
    }
}
