namespace TraktNET
{
    /// <summary>Represents user browsing settings to update.</summary>
    public record class TraktUserSettingsBrowsingPost
    {
        /// <summary>Gets or sets whether to show rating prompt.</summary>
        public bool? ShowRatingPrompt { get; set; }

        /// <summary>Gets or sets the user's locale.</summary>
        public string? Locale { get; set; }

        /// <summary>Gets or sets the watch now settings.</summary>
        public TraktUserWatchnowSettings? Watchnow { get; set; }
    }
}
