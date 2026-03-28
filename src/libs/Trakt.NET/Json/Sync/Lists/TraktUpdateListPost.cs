namespace TraktNET
{
    /// <summary>A Trakt list update post.</summary>
    public record class TraktUpdateListPost
    {
        /// <summary>The description for the list.</summary>
        public string? Description { get; set; }

        /// <summary>The sort by value for the list.</summary>
        public TraktSortBy? SortBy { get; set; }

        /// <summary>The sort how value for the list.</summary>
        public TraktSortHow? SortHow { get; set; }

        public void Validate()
        {
            bool hasNoDescription = string.IsNullOrEmpty(Description);
            bool hasNoSortBy = SortBy == null || SortBy == TraktSortBy.Unspecified;
            bool hasNoSortHow = SortHow == null || SortHow == TraktSortHow.Unspecified;

            if (hasNoDescription && hasNoSortBy && hasNoSortHow)
            {
                throw new TraktPostValidationException("no list update values set");
            }
        }
    }
}
