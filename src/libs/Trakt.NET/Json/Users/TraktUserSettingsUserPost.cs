namespace TraktNET
{
    /// <summary>Represents user profile settings to update.</summary>
    public record class TraktUserSettingsUserPost
    {
        /// <summary>Gets or sets the display name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the about section text.</summary>
        public string? About { get; set; }

        /// <summary>Gets or sets the location name.</summary>
        public string? Location { get; set; }

        /// <summary>Gets or sets whether the account is private.</summary>
        public bool? Private { get; set; }

        /// <summary>Gets or sets the date of birth (as string).</summary>
        public string? Dob { get; set; }
    }
}
