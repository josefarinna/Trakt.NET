namespace TraktNET
{
    /// <summary>A collection containing the number of movies, shows, seasons, episodes and people.</summary>
    public record class TraktUserPersonalListItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public uint? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        public uint? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        public uint? Seasons { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        public uint? Episodes { get; set; }

        /// <summary>Gets or sets the number of people.</summary>
        public uint? People { get; set; }
    }
}
