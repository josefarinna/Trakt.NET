namespace TraktNET
{
    /// <summary>Determines the reaction type.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktReactionType
    {
        /// <summary>An invalid reaction type.</summary>
        Unspecified,

        /// <summary>The reaction type for like.</summary>
        Like,

        /// <summary>The reaction type for dislike.</summary>
        Dislike,

        /// <summary>The reaction type for love.</summary>
        Love,

        /// <summary>The reaction type for laugh.</summary>
        Laugh,

        /// <summary>The reaction type for shocked.</summary>
        Shocked,

        /// <summary>The reaction type for bravo.</summary>
        Bravo,

        /// <summary>The reaction type for spoiler.</summary>
        Spoiler
    }
}
