namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a season was not found.</summary>
    public partial class TraktApiSeasonNotFoundException : TraktApiShowNotFoundException
    {
        /// <summary>The not found season number.</summary>
        public uint SeasonNumber { get; }
    }
}
