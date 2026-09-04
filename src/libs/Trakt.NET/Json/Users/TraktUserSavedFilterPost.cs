namespace TraktNET
{
    /// <summary>Post payload for creating a user saved filter.</summary>
    public record class TraktUserSavedFilterPost
    {
        /// <summary>Gets or sets the name of the saved filter.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the URL of the saved filter.</summary>
        public string? Url { get; set; }
    }
}
