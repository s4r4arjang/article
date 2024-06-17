using AtrinCode.Core.Domain.PagingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EndPoint.Web.Admin.TagHelpers.Paging
{
    public class PaginationTagHelper : TagHelper
    {


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        //private readonly IUrlHelper _urlHelper;
        public PaginationTagHelper(/*IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory*/)
        {
           // _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            //var s = _urlHelper.ActionContext.RouteData;


        }
        


        [HtmlAttributeName("pager-model")]
        public PagingData Model { get; set; }

        [HtmlAttributeName("action")]
        public string Action { get; set; }

        [HtmlAttributeName("contoller")]
        public string Contoller { get; set; }


        [HtmlAttributeName("area")]
        public string Area { get; set; }

        [HtmlAttributeName("filter")]
        public object Filter { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (Model == null)
            {
                return;
            }

            if (Model.TotalPage == 0)
            {
                return;
            }


            TagBuilder divpageabove = new TagBuilder("div");
            //divpageabove.Attributes["class"] = "col-sm-12 col-md-7";
            TagBuilder diventer = new TagBuilder("div");
            diventer.Attributes["class"] = "dataTables_paginate paging_simple_numbers ";
            diventer.Attributes["id"] = "order-listing_paginate";
            divpageabove.InnerHtml.AppendHtml(diventer);

            TagBuilder ulPaging = new TagBuilder("ul");
            ulPaging.Attributes["class"] = "pagination";
            TagBuilder liPreviousPage = new TagBuilder("li");


            liPreviousPage.Attributes["id"] = "order-listing_previous";

            string PreviousDisableClass = Model.CurrentPage == 1 ? "paginate_button page-item previous disabled" : "paginate_button page-item previous";

            liPreviousPage.Attributes["class"] = PreviousDisableClass;

            ulPaging.InnerHtml.AppendHtml(liPreviousPage);
            TagBuilder aTagPreviousPage = new TagBuilder("a");
            string href = $"/{Contoller}/{Action}?CurrentPage={Model.CurrentPage - 1}&PageSize={Model.PageSize}";


            aTagPreviousPage.Attributes["aria-controls"] = "order-listing";
            aTagPreviousPage.Attributes["data-dt-idx"] = "0";
            aTagPreviousPage.Attributes["tabindex"] = "0";
            aTagPreviousPage.Attributes["class"] = "page-link";
            aTagPreviousPage.Attributes["href"] = href;
            aTagPreviousPage.InnerHtml.AppendHtml("قبلی");
            liPreviousPage.InnerHtml.AppendHtml(aTagPreviousPage);
            var startindex = Model.pagestartend;

            for (int i = startindex.start; i <= startindex.end; i++)
            {

                TagBuilder liPaging = new TagBuilder("li");

                string liPagingClass = Model.CurrentPage == i ? "paginate_button page-item  active" : "order-listing_previous";

                liPaging.Attributes["class"] = liPagingClass;

                TagBuilder aTagPaging = new TagBuilder("a");

                string hrefPaging = $"/{Contoller}/{Action}?CurrentPage={i}&PageSize={Model.PageSize}";


                aTagPaging.Attributes["aria-controls"] = "order-listing";
                aTagPaging.Attributes["data-dt-idx"] = "1";
                aTagPaging.Attributes["tabindex"] = "0";
                aTagPaging.Attributes["class"] = "page-link";
                aTagPaging.Attributes["href"] = hrefPaging;
                aTagPaging.InnerHtml.AppendHtml(i.ToString());
                liPaging.InnerHtml.AppendHtml(aTagPaging);
                ulPaging.InnerHtml.AppendHtml(liPaging);


            }

            TagBuilder linextPage = new TagBuilder("li");


            linextPage.Attributes["id"] = "order-listing";

            string NextDisableClass = Model.CurrentPage == Model.TotalPage ? "paginate_button page-item next disabled" : "paginate_button page-item next";

            linextPage.Attributes["class"] = NextDisableClass;
            ulPaging.InnerHtml.AppendHtml(linextPage);
            TagBuilder aTagnextPage = new TagBuilder("a");
            string hrefnextPage = $"/{Contoller}/{Action}?CurrentPage={Model.CurrentPage + 1}&PageSize={Model.PageSize}";


            aTagnextPage.Attributes["aria-controls"] = "order-listing";
            aTagnextPage.Attributes["data-dt-idx"] = "1";
            aTagnextPage.Attributes["tabindex"] = "0";
            aTagnextPage.Attributes["class"] = "page-link";
            aTagnextPage.Attributes["href"] = hrefnextPage;
            aTagnextPage.InnerHtml.AppendHtml("بعدی");
            linextPage.InnerHtml.AppendHtml(aTagnextPage);

            diventer.InnerHtml.AppendHtml(ulPaging);

            output.Content.AppendHtml(divpageabove);

        }
    }
}
