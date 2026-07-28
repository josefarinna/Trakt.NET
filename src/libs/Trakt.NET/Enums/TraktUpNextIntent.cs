namespace TraktNET
{
    /// <summary>Determines the intent of the up next nitro progress request.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktUpNextIntent
    {
        /// <summary>An invalid intent type.</summary>
        Unspecified,

        /// <summary>Get all shows.</summary>
        All,

        /// <summary>Get shows the user is currently continuing.</summary>
        Continue,

        /// <summary>Get shows the user is just starting.</summary>
        Start,

        /// <summary>Get completed shows.</summary>
        Completed
    }
}
