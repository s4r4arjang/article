using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EndPoint.Web.Admin.TagHelpers.Paging
{
    public class PageSizeTagHelper : TagHelper
    {

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public int First { get; set; } = 10;
        public int End { get; set; } = 50;
        public int Step { get; set; } = 10;
        public int ItemSelected { get; set; } = 10;

        [HtmlAttributeName("action")]
        public string Action { get; set; }

        [HtmlAttributeName("contoller")]
        public string Controller { get; set; }


        [HtmlAttributeName("area")]
        public string Area { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {



            TagBuilder div = new TagBuilder("div");

            TagBuilder SelectPageSize = new TagBuilder("select");

            for (int i = First; i <= End; i += Step)
            {
                TagBuilder selectOption = new TagBuilder("option");
                selectOption.Attributes["value"] = i.ToString();

                if (i == ItemSelected)
                {
                    selectOption.Attributes["selected"] = "selected";
                }


                selectOption.InnerHtml.AppendHtml(
                string.Format("{0}", i));
                SelectPageSize.InnerHtml.AppendHtml(selectOption);

            }
            SelectPageSize.Attributes["onchange"] = "SendPageSize(this.value)";
            //SelectPageSize.Attributes["style"] = "float: left; height: 37px;";

            div.InnerHtml.AppendHtml(SelectPageSize);

            TagBuilder scriptPageSize = new TagBuilder("script");

            string href = Area == null ? $"/{Controller}/{Action}" : $"/{Area}/{Controller}/{Action}";

            var ItemsPageSizeSelected = @" function SendPageSize(SelectedValue)
            {
               
          window.location.href ='" + href + @"?CurrentPage=' + 1 + '&PageSize=' + SelectedValue;
            }
";

            scriptPageSize.InnerHtml.AppendHtml(ItemsPageSizeSelected);

            div.InnerHtml.AppendHtml(scriptPageSize);

            output.Content.AppendHtml(div);




        }
    }
}
