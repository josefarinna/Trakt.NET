namespace TraktNET
{
    /// <summary>A collection containing the number of movies and episodes.</summary>
    public record class TraktSyncCollectionPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public uint? Movies { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        public uint? Episodes { get; set; }
    }
}

