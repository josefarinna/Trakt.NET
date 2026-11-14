namespace TraktNET
{
    /// <summary>Determines the kind of an award in the award catalog.</summary>
    [TraktEnum]
    public enum TraktAwardKind
    {
        /// <summary>An invalid award kind.</summary>
        Unspecified,

        /// <summary>The award is for a title (movie or show).</summary>
        Title,

        /// <summary>The award is for a person.</summary>
        Person
    }
}
