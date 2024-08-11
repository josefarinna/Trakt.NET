namespace TraktNET
{
    /// <summary>A collection of Trakt headers.</summary>
    public interface ITraktPagedResponseHeaders
    {
        /// <summary>The Trakt "X-Pagination-Page-Count" header.</summary>
        uint? PageCount { get; }

        /// <summary>The Trakt "X-Pagination-Item-Count" header.</summary>
        uint? ItemCount { get; }
    }
}
