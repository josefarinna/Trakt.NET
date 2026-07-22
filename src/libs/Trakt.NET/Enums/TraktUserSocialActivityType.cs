namespace TraktNET
{
    /// <summary>Determines the type of social activity for a user.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktUserSocialActivityType
    {
        /// <summary>An invalid social activity type.</summary>
        Unspecified,

        /// <summary>Activity for friends.</summary>
        Friends,

        /// <summary>Activity for followers.</summary>
        Followers,

        /// <summary>Activity for following.</summary>
        Following
    }
}
