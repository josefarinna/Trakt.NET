namespace TraktNET
{
    /// <summary>Determines the logical operator used for filtering.</summary>
    [TraktEnum]
    public enum TraktFilterOperator
    {
        /// <summary>An invalid filter operator.</summary>
        Unspecified,

        /// <summary>Matches all values.</summary>
        And,

        /// <summary>Matches any of the values.</summary>
        Or
    }
}

