using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.Enum
{
    public enum ArticleStatus
    {
        [Description("دیده نشده")]
        New = 0,
        [Description("در حال بررسی")]
        Pending = 1,
        [Description("رد شده")]
        Rejected = 2 ,
        [Description("تایید شده")]
        Accepted = 3 ,
     
    }
}
