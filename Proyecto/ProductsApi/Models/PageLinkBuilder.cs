using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Routing;

public class PageLinkBuilder
{
    public Uri FirstPage { get; private set; }
    public Uri LastPage { get; private set; }
    public Uri NextPage { get; private set; }
    public Uri PreviousPage { get; private set; }

    public PageLinkBuilder(UrlHelper urlHelper, string routeName, object routeValues, int pageNo, int pageSize, long totalRecordCount)
    {
        // Determine total number of pages
        var pageCount = totalRecordCount > 0
            ? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
            : 0;

        // Create them page links 
        FirstPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
        {
            {"pageNo", 1},
            {"pageSize", pageSize}
        }));
        LastPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
        {
            {"pageNo", pageCount},
            {"pageSize", pageSize}
        }));
        if (pageNo > 1)
        {
            PreviousPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                {"pageNo", pageNo - 1},
                {"pageSize", pageSize}
            }));
        }
        if (pageNo < pageCount)
        {
            NextPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                {"pageNo", pageNo + 1},
                {"pageSize", pageSize}
            }));
        }
    }

    public PageLinkBuilder(IUrlHelper url, string v1, string v2, int pageNo, int pageSize, int total)
    {
    }
}
