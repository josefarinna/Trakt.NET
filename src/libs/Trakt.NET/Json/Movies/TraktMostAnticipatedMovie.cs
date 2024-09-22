namespace TraktNET
{
    /// <summary>A most anticipated Trakt movie.</summary>
    public record class TraktMostAnticipatedMovie : TraktCollectionMovie
    {
        /// <summary>The list count for the <see cref="Movie" />.</summary>
        public uint? ListCount { get; set; }
    }
}
