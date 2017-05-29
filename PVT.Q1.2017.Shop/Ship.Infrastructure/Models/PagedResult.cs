namespace Shop.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    ///     Represents the paged results.
    /// </summary>
    /// <remarks>
    ///     Idea is taken from Gunnar Peipman's ASP.NET blog:
    ///     https://weblogs.asp.net/gunnarpeipman/returning-paged-results-from-repositories-using-pagedresult-lt-t-gt
    /// </remarks>
    public class PagedResult<T>
    {
        /// <summary>
        /// </summary>
        private readonly int _currentPage;

        /// <summary>
        /// </summary>
        private readonly ICollection<T> _items;

        /// <summary>
        /// </summary>
        private readonly int _pagesCount;

        /// <summary>
        /// </summary>
        private readonly int _pageSize;

        /// <summary>
        /// </summary>
        private readonly int _totalItemsCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResult{T}"/> class.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="totalItemsCount">
        /// The total items count.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public PagedResult(ICollection<T> items, int pageSize, int page, int totalItemsCount)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this._items = items;

            if (pageSize <= 0)
            {
                pageSize = 1;
            }

            if (totalItemsCount < items.Count)
            {
                totalItemsCount = items.Count;
            }

            this._pageSize = pageSize;
            this._totalItemsCount = totalItemsCount;

            this._pagesCount = (int)Math.Ceiling((double)this._totalItemsCount / this._pageSize);

            if (page <= 0)
            {
                page = 1;
            }

            if(_pagesCount>0)
            {
                this._currentPage = page > this._pagesCount ? this._pagesCount : page;
            }
            else
            {
                this._currentPage = 1;
            }
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return this._currentPage;
            }
        }

        /// <summary>
        ///     Gets the items.
        /// </summary>
        public ICollection<T> Items
        {
            get
            {
                return this._items;
            }
        }

        /// <summary>
        /// Gets the pages count.
        /// </summary>
        public int PagesCount
        {
            get
            {
                return this._pagesCount;
            }
        }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
        }

        /// <summary>
        /// Gets the total items count.
        /// </summary>
        public int TotalItemsCount
        {
            get
            {
                return this._totalItemsCount;
            }
        }
    }
}