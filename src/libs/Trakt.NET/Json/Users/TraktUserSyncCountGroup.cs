namespace TraktNET
{
    /// <summary>Represents counts per media type in a sync section.</summary>
    public record class TraktUserSyncCountGroup
    {
        /// <summary>Gets or sets the movie count.</summary>
        public uint? Movies { get; set; }

        /// <summary>Gets or sets the episode count.</summary>
        public uint? Episodes { get; set; }

        /// <summary>Gets or sets the show count.</summary>
        public uint? Shows { get; set; }

        /// <summary>Gets or sets the season count.</summary>
        public uint? Seasons { get; set; }
    }
}
