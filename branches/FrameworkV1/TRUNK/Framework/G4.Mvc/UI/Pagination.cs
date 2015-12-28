namespace G4.Mvc.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Routing;

    /// <summary>
    /// PagedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>, IDisposable
    {
        public PageInfo PageInfo;
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalCnt">The total CNT.</param>
        /// <param name="maxPageNumber">The max page number.</param>
        public PagedList(IEnumerable<T> source, int index, int pageSize, int totalCnt, int maxPageNumber)
        {
            PageInfo = new PageInfo();
            PageInfo.TotalCount = totalCnt;
            PageInfo.TotalPageCount = (int)Math.Ceiling((double)totalCnt / pageSize);
            PageInfo.PageSize = pageSize;
            PageInfo.PageIndex = index;
            PageInfo.MaxPageNumbers = maxPageNumber;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
            SetPageRange();
        }

        /// <summary>
        /// Sets the page range.
        /// </summary>
        private void SetPageRange()
        {

            if (PageInfo.PageIndex >= PageInfo.MaxPageNumbers)
            {
                int iRem;
                int iRslt = Math.DivRem(PageInfo.PageIndex, PageInfo.MaxPageNumbers, out iRem);

                if (iRem == 0)
                {
                    PageInfo.End = PageInfo.PageIndex;
                    PageInfo.Start = PageInfo.End - (PageInfo.MaxPageNumbers - 1);
                    PageInfo.IsPreviousPage = PageInfo.Start != 1;
                    PageInfo.IsNextPage = PageInfo.TotalPageCount > PageInfo.End;

                }
                else
                {
                    if (PageInfo.TotalPageCount > (iRslt + 1) * PageInfo.MaxPageNumbers)
                    {
                        PageInfo.End = (iRslt + 1) * PageInfo.MaxPageNumbers;
                        PageInfo.IsNextPage = true;
                    }
                    else
                    {
                        PageInfo.End = PageInfo.PageIndex > PageInfo.TotalPageCount ? PageInfo.PageIndex : PageInfo.TotalPageCount;
                        PageInfo.IsNextPage = false;
                    }

                    PageInfo.Start = iRslt * PageInfo.MaxPageNumbers + 1;
                    PageInfo.IsPreviousPage = true;
                }
            }
            else
            {
                PageInfo.Start = 1;
                PageInfo.IsPreviousPage = false;

                if (PageInfo.TotalPageCount > PageInfo.MaxPageNumbers)
                {
                    PageInfo.IsNextPage = true;
                    PageInfo.End = PageInfo.MaxPageNumbers;
                }
                else
                {
                    PageInfo.IsNextPage = false;
                    PageInfo.End = PageInfo.PageIndex > PageInfo.TotalPageCount ? PageInfo.PageIndex : PageInfo.TotalPageCount;
                }
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion
    }

    public class PageInfo
    {
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        public int End { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total page count.
        /// </summary>
        /// <value>The total page count.</value>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the max page numbers.
        /// </summary>
        /// <value>The max page numbers.</value>
        public int MaxPageNumbers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is previous page.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is previous page; otherwise, <c>false</c>.
        /// </value>
        public bool IsPreviousPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is next page.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is next page; otherwise, <c>false</c>.
        /// </value>
        public bool IsNextPage { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        public string Controller { get; set; }

        /// <summary>
        /// Gets or sets the route value dictionary.
        /// </summary>
        /// <value>
        /// The route value dictionary.
        /// </value>
        public RouteValueDictionary RouteValueDictionary { get; set; }
    }

    /// <summary>
    /// Pagination Class
    /// </summary>
    public static class Pagination
    {
        /// <summary>
        /// Toes the paged list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalCnt">The total CNT.</param>
        /// <param name="maxPageNumber">The max page number.</param>
        /// <returns>PageInfo</returns>
        public static PageInfo ToPagedList<T>(this IList<T> source, int index, int pageSize, int totalCnt, int maxPageNumber)
        {
            return new PagedList<T>(source, index, pageSize, totalCnt, maxPageNumber).PageInfo;
        }

        /// <summary>
        /// Toes the paged list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <param name="totalCnt">The total CNT.</param>
        /// <param name="maxPageNumber">The max page number.</param>
        /// <returns>PageInfo</returns>
        public static PageInfo ToPagedList<T>(this IList<T> source, int index, int totalCnt, int maxPageNumber)
        {
            return new PagedList<T>(source, index, 10, totalCnt, maxPageNumber).PageInfo;
        }
    }
}