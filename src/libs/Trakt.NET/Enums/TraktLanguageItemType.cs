namespace TraktNET
{
    /// <summary>Determines the type of an object in a language item.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktLanguageItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The language item contains a movie.</summary>
        Movies,

        /// <summary>The language item contains a show.</summary>
        Shows
    }
}
