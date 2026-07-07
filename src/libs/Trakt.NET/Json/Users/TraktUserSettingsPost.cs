namespace TraktNET
{
    /// <summary>Represents settings to update for a user.</summary>
    public record class TraktUserSettingsPost
    {
        /// <summary>Gets or sets user profile settings to update.</summary>
        public TraktUserSettingsUserPost? User { get; set; }

        /// <summary>Gets or sets user browsing settings to update.</summary>
        public TraktUserSettingsBrowsingPost? Browsing { get; set; }
    }
}
