namespace TraktNET
{
    /// <summary>Represents Trakt user settings.</summary>
    public record class TraktUserSettings
    {
        /// <summary>
        /// Gets or sets the Trakt user for this settings.
        /// See also <seealso cref="TraktUser" />.
        /// </summary>
        public TraktUser? User { get; set; }

        /// <summary>
        /// Gets or sets the account settings.
        /// See also <seealso cref="TraktAccountSettings" />.
        /// </summary>
        public TraktAccountSettings? Account { get; set; }

        /// <summary>
        /// Gets or sets the social media connection settings.
        /// See also <seealso cref="TraktConnections" />.
        /// </summary>
        public TraktConnections? Connections { get; set; }

        /// <summary>
        /// Gets or sets the social media sharing text settings.
        /// See also <seealso cref="TraktSharingText" />.
        /// </summary>
        public TraktSharingText? SharingText { get; set; }

        /// <summary>
        /// Gets or sets the user's limits.
        /// See also <seealso cref="TraktUserLimits" />.
        /// </summary>
        public TraktUserLimits? Limits { get; set; }

        /// <summary>
        /// Gets or sets the user's permissions.
        /// See also <seealso cref="TraktPermissions" />.
        /// </summary>
        public TraktPermissions? Permissions { get; set; }
    }
}
