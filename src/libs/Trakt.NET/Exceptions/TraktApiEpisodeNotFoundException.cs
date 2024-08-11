namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an episode was not found.</summary>
    public sealed partial class TraktApiEpisodeNotFoundException : TraktApiSeasonNotFoundException
    {
        /// <summary>The not found episode number.</summary>
        public uint EpisodeNumber { get; }
    }
}
