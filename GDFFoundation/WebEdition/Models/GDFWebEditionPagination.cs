

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a pagination configuration for web edition in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFWebEditionPagination
    {
        /// <summary>
        /// Represents pagination settings for web edition.
        /// </summary>
        public const int K_PageRange = 2;

        /// <summary>
        /// Gets or sets a value indicating whether the JSON clipboard feature is enabled.
        /// </summary>
        /// <value><c>true</c> if the JSON clipboard feature is enabled; otherwise, <c>false</c>.</value>
        public bool JsonClipboard { set; get; } = false;

        /// <summary>
        /// Gets or sets the default values.
        /// </summary>
        public string DefaultValues { set; get; } = "";

        /// <summary>
        /// Represents the number of items per page in a pagination system.
        /// </summary>
        public int ItemPerPage { set; get; } = 5;

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int PageCount { set; get; } = 1;

        /// <summary>
        /// Gets or sets the active page of the pagination.
        /// </summary>
        public int ActivePage { set; get; } = 1;

        /// <summary>
        /// Represents the sorting criteria used for pagination in the GDFWebEditionPagination class.
        /// </summary>
        public string SortBy { set; get; } = "";

        /// <summary>
        /// Represents the options for the number of items per page in pagination.
        /// </summary>
        public int[] ItemsPerPageOptions { set; get; } = new int[] { 5, 10, 20, 30 };

        /// <summary>
        /// Represents the available options for sorting.
        /// </summary>
        public string[] SortByOptions { set; get; } = new string[] { "Title", "Description", "Reference" };

        /// <summary>
        /// Represents the columns to be displayed in a table.
        /// </summary>
        public string[] Columns { set; get; } = new string[] { "Reference" };

        /// <summary>
        /// Gets or sets the primary column for sorting and display purposes.
        /// </summary>
        /// <value>The primary column.</value>
        public string ColumnPrimary { set; get; } = "Reference";

        /// <summary>
        /// Specifies the sort direction for sorting operations.
        /// </summary>
        public GDFWebEditionSortDirection SortDirection { set; get; } = GDFWebEditionSortDirection.Ascending;

        /// <summary>
        /// Represents pagination properties for web editions.
        /// </summary>
        /// <remarks>
        /// This class provides properties for pagination related to web editions. It includes properties such as:
        /// - JsonClipboard: Indicates if the pagination should use JSON clipboard.
        /// - DefaultValues: The default values for the pagination.
        /// - ItemPerPage: The number of items to display per page.
        /// - PageCount: The total number of pages.
        /// - ActivePage: The current active page.
        /// - SortBy: The field to sort the items by.
        /// - ItemsPerPageOptions: The available options for items to display per page.
        /// - SortByOptions: The available options for sorting the items.
        /// - Columns: The columns to display.
        /// - ColumnPrimary: The primary column to use.
        /// - SortDirection: The direction of the sort.
        /// - Reference: The reference being used for filtering.
        /// - PagePreview: The previous page.
        /// - PageFirst: The first page.
        /// - PageLast: The last page.
        /// - PageNext: The next page.
        /// - PageMin: The minimum page number.
        /// - PageMax: The maximum page number.
        /// - ShowReference: Indicates if the reference should be shown.
        /// - ShowButton: Indicates if the button should be shown.
        /// </remarks>
        public string Reference { set; get; } = "";

        /// <summary>
        /// Represents the class for managing pagination in a web edition.
        /// </summary>
        public int PagePreview => Math.Max(ActivePage - 1, 1);

        /// <summary>
        /// Gets or sets the first page number for pagination.
        /// </summary>
        public int PageFirst { set; get; } = 1;

        /// <summary>
        /// Gets the last page number.
        /// </summary>
        /// <returns>The last page number.</returns>
        public int PageLast => PageCount;

        /// <summary>
        /// Gets the next page number based on the active page and the total number of pages.
        /// </summary>
        /// <value>
        /// The next page number.
        /// </value>
        public int PageNext => Math.Min(ActivePage + 1, PageCount);

        /// <summary>
        /// Gets the minimum page number based on the active page and the page range.
        /// </summary>
        /// <remarks>
        /// The PageMin property calculates the minimum page number based on the active page and the page range.
        /// The ActivePage property represents the currently active page.
        /// The K_PageRange constant defines the range of pages displayed on the pagination control.
        /// This property ensures that the minimum page number is never less than 1.
        /// </remarks>
        public int PageMin => Math.Max(ActivePage - K_PageRange, 1);

        /// <summary>
        /// Represents the maximum page number for pagination.
        /// </summary>
        /// <remarks>
        /// This property determines the maximum page number for pagination based on the <see cref="ActivePage"/> and <see cref="PageCount"/> properties.
        /// The value is calculated as the minimum of the sum of the <see cref="ActivePage"/> and 1, and the <see cref="PageCount"/>.
        /// </remarks>
        public int PageMax => Math.Min(ActivePage + 1, PageCount);

        /// <summary>
        /// Determines whether the reference should be shown or not.
        /// </summary>
        /// <remarks>
        /// Default value is false.
        /// </remarks>
        public bool ShowReference { set; get; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the button should be shown.
        /// </summary>
        public bool ShowButton { set; get; } = false;

        /// <summary>
        /// Create a new instance of GDFWebEditionPagination with specified ItemPerPage value.
        /// </summary>
        /// <param name="sItemPerPage">The number of items per page.</param>
        /// <returns>A new instance of GDFWebEditionPagination with specified ItemPerPage value.</returns>
        public GDFWebEditionPagination NewItemPerPage(int sItemPerPage)
        {
            return new GDFWebEditionPagination()
            {
                ItemPerPage = sItemPerPage,
                ActivePage = this.ActivePage,
                SortBy = this.SortBy,
                Reference = this.Reference,
                SortDirection = this.SortDirection,
                ShowReference = this.ShowReference,
                ShowButton = this.ShowButton,
                DefaultValues = this.DefaultValues,
            };
        }

        /// <summary>
        /// Creates a new instance of GDFWebEditionPagination with the specified active page.
        /// </summary>
        /// <param name="sActivePage">The active page value.</param>
        /// <returns>A new instance of GDFWebEditionPagination with the specified active page.</returns>
        public GDFWebEditionPagination NewActivePage(int sActivePage)
        {
            return new GDFWebEditionPagination()
            {
                ItemPerPage = this.ItemPerPage,
                ActivePage = sActivePage,
                SortBy = this.SortBy,
                Reference = this.Reference,
                SortDirection = this.SortDirection,
                ShowReference = this.ShowReference,
                ShowButton = this.ShowButton,
                DefaultValues = this.DefaultValues,
            };
        }

        /// <summary>
        /// Creates a new instance of GDFWebEditionPagination with the specified sort by parameter.
        /// </summary>
        /// <param name="sSortBy">The sort by parameter.</param>
        /// <returns>A new instance of GDFWebEditionPagination with the specified sort by parameter.</returns>
        public GDFWebEditionPagination NewSortBy(string sSortBy)
        {
            return new GDFWebEditionPagination()
            {
                ItemPerPage = this.ItemPerPage,
                ActivePage = this.ActivePage,
                SortBy = sSortBy,
                Reference = this.Reference,
                SortDirection = this.SortDirection,
                ShowReference = this.ShowReference,
                ShowButton = this.ShowButton,
                DefaultValues = this.DefaultValues,
            };
        }

        /// <summary>
        /// Creates a new instance of GDFWebEditionPagination with the given sort direction.
        /// </summary>
        /// <param name="sSortDirection">The sort direction to set for the new pagination instance.</param>
        /// <returns>A new instance of GDFWebEditionPagination with the specified sort direction.</returns>
        public GDFWebEditionPagination NewSortDirection(GDFWebEditionSortDirection sSortDirection)
        {
            return new GDFWebEditionPagination()
            {
                ItemPerPage = this.ItemPerPage,
                ActivePage = this.ActivePage,
                SortBy = this.SortBy,
                Reference = this.Reference,
                SortDirection = sSortDirection,
                ShowReference = this.ShowReference,
                ShowButton = this.ShowButton,
                DefaultValues = this.DefaultValues,
            };
        }

        /// <summary>
        /// Creates a new instance of the GDFWebEditionPagination class with a specified reference string.
        /// </summary>
        /// <param name="sReference">The reference string to set for the new instance.</param>
        /// <returns>A new instance of the GDFWebEditionPagination class with the specified reference string.</returns>
        public GDFWebEditionPagination NewReference(string sReference)
        {
            return new GDFWebEditionPagination()
            {
                ItemPerPage = this.ItemPerPage,
                ActivePage = this.ActivePage,
                SortBy = this.SortBy,
                Reference = sReference,
                SortDirection = this.SortDirection,
                ShowReference = this.ShowReference,
                ShowButton = this.ShowButton,
                DefaultValues = this.DefaultValues,
            };
        }

    }
}

