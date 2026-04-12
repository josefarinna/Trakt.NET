namespace TraktNET
{
    /// <summary>A collection containing the number of movies, shows and seasons.</summary>
    public record class TraktUserHiddenItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public uint? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        public uint? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        public uint? Seasons { get; set; }

        /// <summary>Gets or sets the number of users.</summary>
        public uint? Users { get; set; }
    }
}
