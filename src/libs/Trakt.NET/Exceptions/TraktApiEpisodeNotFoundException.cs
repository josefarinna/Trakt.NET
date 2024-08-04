namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an episode was not found.</summary>
    public sealed partial class TraktApiEpisodeNotFoundException : TraktApiSeasonNotFoundException
    {
        public uint EpisodeNumber { get; }
    }
}
