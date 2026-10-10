namespace TraktNET
{
    /// <summary>Determines the role used for filtering people.</summary>
    [TraktEnum]
    public enum TraktPeopleRole
    {
        /// <summary>An invalid people role.</summary>
        Unspecified,

        /// <summary>Matches any role.</summary>
        Any,

        /// <summary>Matches cast role.</summary>
        Cast,

        /// <summary>Matches directing role.</summary>
        Directing,

        /// <summary>Matches writing role.</summary>
        Writing,

        /// <summary>Matches producing role.</summary>
        Producing
    }
}
