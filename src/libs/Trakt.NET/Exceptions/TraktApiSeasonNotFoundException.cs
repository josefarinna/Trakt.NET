namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a season was not found.</summary>
    public partial class TraktApiSeasonNotFoundException : TraktApiShowNotFoundException
    {
        public uint SeasonNumber { get; }
    }
}
