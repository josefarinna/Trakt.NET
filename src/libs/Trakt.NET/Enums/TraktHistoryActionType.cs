namespace TraktNET
{
    /// <summary>Determines the action type of an history item.</summary>
    [TraktEnum]
    public enum TraktHistoryActionType
    {
        /// <summary>An invalid action type.</summary>
        Unspecified,

        /// <summary>The history item is / was scrobbled.</summary>
        Scrobble,

        /// <summary>The history item is / was checked in.</summary>
        Checkin,

        /// <summary>The history item is / was watched.</summary>
        Watch
    }
}
