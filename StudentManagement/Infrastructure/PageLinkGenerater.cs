using System;
using System.Text;
using System.Web.Mvc;

namespace StudentManagement.Infrastructure
{
    public static class PageLinkGenerater
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            GeneratePrevNextButton("Previous Page", pageUrl(pagingInfo.PageIndex - 1), pagingInfo.HasPrevPage, result);

            for (int i = 1; i <= pagingInfo.TotalPageCount; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.PageIndex)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            GeneratePrevNextButton("Next Page", pageUrl(pagingInfo.PageIndex + 1), pagingInfo.HasNextPage, result);

            return MvcHtmlString.Create(result.ToString());
        }

        private static void GeneratePrevNextButton(string buttonText, string link, bool isEnabled, StringBuilder result)
        {
            TagBuilder nextTag = new TagBuilder("a");

            if (isEnabled)
            {
                nextTag.MergeAttribute("href", link);
                nextTag.AddCssClass("btn btn-danger");
            }
            else
            {
                nextTag.MergeAttribute("href", "#");
                nextTag.AddCssClass("btn btn-danger disabled");
            }

            nextTag.InnerHtml = buttonText;
            result.Append(nextTag.ToString());
        }
    }
}