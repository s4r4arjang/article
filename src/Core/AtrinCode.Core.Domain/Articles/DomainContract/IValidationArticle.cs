using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.Entities.Articles.DomainContract
{
    public interface IValidationArticle
    {
        bool ExistTitle( int exceptArticleId , string title);
        bool ExistTitle(string title);

    }
}
