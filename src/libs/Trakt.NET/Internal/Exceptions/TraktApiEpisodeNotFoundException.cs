namespace TraktNET
{
    public sealed partial class TraktApiEpisodeNotFoundException
    {
        internal TraktApiEpisodeNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base("Episode Not Found - method exists, but no record found", parameters, innerException)
            => EpisodeNumber = parameters.EpisodeNr;
    }
}
