namespace TraktNET
{
    /// <summary>A Trakt user post show episode, containing the required episode number.</summary>
    public record class TraktUserRemovePostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public uint Number { get; set; }
    }
}
