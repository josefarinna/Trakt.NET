namespace TraktNET
{
    /// <summary>Post payload for creating a user saved filter.</summary>
    public record class TraktUserSavedFilterPost
    {
        /// <summary>
        /// Gets or sets the filter section of the saved filter.
        /// See also <seealso cref="TraktFilterSection" />.
        /// </summary>
        public TraktFilterSection? Section { get; set; }

        /// <summary>Gets or sets the name of the saved filter.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the path of the saved filter.</summary>
        public string? Path { get; set; }

        /// <summary>Gets or sets the query of the saved filter.</summary>
        public string? Query { get; set; }
    }
}
