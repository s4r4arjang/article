

using AtrinCode.Core.Contracts.Common;

namespace AtrinCode.Core.Contracts.Services.Articles.Command
{
    public class CreateCategoryCommand: ICommand
    {
        public string Title { get; set; }
    }
}
