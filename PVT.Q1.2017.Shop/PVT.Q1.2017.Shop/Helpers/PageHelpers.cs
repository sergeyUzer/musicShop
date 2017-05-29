namespace PVT.Q1._2017.Shop.Helpers
{
    using System;
    using System.Text;
    using System.Web.Mvc;
    using global::Shop.Infrastructure.Models;

    /// <summary>
    /// Class for page displaying
    /// </summary>
    public static class PageHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pageInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks<T>(this HtmlHelper helper, PagedResult<T> pageInfo, Func<int, string> url, int totalVisiblePages = 5)
        {
            StringBuilder result = new StringBuilder();

            int middle = (int)Math.Ceiling((double)totalVisiblePages / 2);

            int firstVisiblePage = pageInfo.CurrentPage < middle ? 1 : pageInfo.CurrentPage - middle + 1;
            int lastVisiblePage = firstVisiblePage + totalVisiblePages - 1;
            if (lastVisiblePage > pageInfo.PagesCount)
            {
                lastVisiblePage = pageInfo.PagesCount;
            }

            if (lastVisiblePage - firstVisiblePage + 1 < totalVisiblePages)
            {
                firstVisiblePage -= totalVisiblePages - (lastVisiblePage - firstVisiblePage + 1);
                if (firstVisiblePage <= 0)
                {
                    firstVisiblePage = 1;
                }
            }

            TagBuilder tag;
            if (firstVisiblePage > 1)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", url(1));
                tag.InnerHtml = "Первая";
                tag.AddCssClass("btn btn-default");
                result.Append(tag);
            }

            for (int i = firstVisiblePage; i <= lastVisiblePage; i++)
            {
                if (i > 0 && i <= pageInfo.PagesCount)
                {
                    tag = new TagBuilder("a");
                    tag.MergeAttribute("href", url(i));
                    tag.InnerHtml = i.ToString();

                    if (i == pageInfo.CurrentPage)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn btn-primary");
                    }
                    else
                    {
                        tag.AddCssClass("btn btn-default");
                    }

                    result.Append(tag);
                }
            }

            if (lastVisiblePage < pageInfo.PagesCount)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", url(pageInfo.PagesCount));
                tag.InnerHtml = "Последняя";
                tag.AddCssClass("btn btn-default");
                result.Append(tag);
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}