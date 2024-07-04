namespace TraktNET
{
    /// <summary>Determines the type of an access token.</summary>
    [TraktEnum]
    public enum TraktAccessTokenType
    {
        /// <summary>An invalid access token type.</summary>
        Unspecified,

        /// <summary>The access token type for Bearer tokens.</summary>
        Bearer
    }
}
