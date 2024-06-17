using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.DomainServices.Articles
{
    public  interface IValidationCategory
    {
        bool ExistTitle(int exceptCategoryId, string title);
        bool ExistTitle(string title);
        bool NotAllowDelete(int categoryId);
    }

}
