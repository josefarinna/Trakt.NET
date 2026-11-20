namespace TraktNET
{
    /// <summary>A season entry under a show-shaped not found response item.</summary>
    public record class TraktPostResponseNotFoundShowSeason
    {
        /// <summary>Gets or sets the season number.</summary>
        public uint Number { get; set; }

        /// <summary>Gets or sets the optional list of not found episodes within this season.</summary>
        public List<TraktPostResponseNotFoundShowEpisode>? Episodes { get; set; }
    }
}
