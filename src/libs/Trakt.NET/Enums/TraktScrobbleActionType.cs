namespace TraktNET
{
    /// <summary>Determines the action type for a scroblle post.</summary>
    [TraktEnum]
    public enum TraktScrobbleActionType
    {
        /// <summary>An invalid action type.</summary>
        Unspecified,

        /// <summary>The scrobble started.</summary>
        Start,

        /// <summary>The scrobble paused.</summary>
        Pause,

        /// <summary>The scrobble stopped.</summary>
        Stop
    }
}
