namespace TraktNET
{
    /// <summary>Determines the grant type to specify how an access tokenshould be retrieved during authentication.</summary>
    [TraktEnum]
    public enum TraktAccessTokenGrantType
    {
        /// <summary>An invalid access token grant type.</summary>
        Unspecified,

        /// <summary>The grant type to specify the retrieving of an access token with an user code.</summary>
        AuthorizationCode,

        /// <summary>The grant type to specify the retrieving of an access token with a refresh token.</summary>
        RefreshToken
    }
}
