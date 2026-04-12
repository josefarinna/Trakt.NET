namespace TraktNET
{
    /// <summary>Determines the replies to be included.</summary>
    [TraktEnum(HasQuerySupport = true, QueryName = "include_replies")]
    public enum TraktIncludeReplies
    {
        /// <summary>An invalid include reply type.</summary>
        Unspecified,

        /// <summary>Replies should be included.</summary>
        True,

        /// <summary>Replies should not be included.</summary>
        False,

        /// <summary>Replies should only be included and no top level comments.</summary>
        Only
    }
}
