using AtrinCode.Core.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AtrinCode.Core.Contracts.Services.Articles.Command
{

    public class EditCategoryCommand: ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
