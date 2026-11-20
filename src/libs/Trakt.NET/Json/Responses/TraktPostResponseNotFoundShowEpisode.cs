namespace TraktNET
{
    /// <summary>An episode entry under a show-shaped not found response season.</summary>
    public record class TraktPostResponseNotFoundShowEpisode
    {
        /// <summary>Gets or sets the episode number.</summary>
        public uint Number { get; set; }
    }
}
