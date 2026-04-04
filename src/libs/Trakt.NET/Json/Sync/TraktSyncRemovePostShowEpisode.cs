namespace TraktNET
{
    /// <summary>A Trakt sync post show episode, containing the required episode number.</summary>
    public record class TraktSyncRemovePostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public uint Number { get; set; }
    }
}
